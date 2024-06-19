using FluxoDeCaixa.Infra.IoC;
using FluxoDeCaixa.Services.DTO.Request;
using FluxoDeCaixa.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace FluxoDeCaixa.Consolidado.RabbitMQ.Receiver;
class Program
{
    private const string _queue = "consolidado";

    static void Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();
        ConfigureService(serviceCollection);
        var serviceProvider = serviceCollection.BuildServiceProvider();
        var consolidadoService = serviceProvider.GetService<IConsolidadoService>();

        ReceiveMessageConsolidado(consolidadoService);
        Console.ReadKey();

    }


    static async void GravarConsolidadoCaixa(IConsolidadoService consolidadoService, MensagemConsolidadoRequestDTO buscaConsolidado)
    {
        var caixaConsolidado = await consolidadoService.MontarCaixaConsolidado(buscaConsolidado);

        if (caixaConsolidado != null)
            await consolidadoService.GravarCaixaConsolidado(caixaConsolidado);
    }
    static void ReceiveMessageConsolidado(IConsolidadoService consolidadoService)
    {
        var factory = new ConnectionFactory
        {
            HostName = "localhost"
        };

        var connection = factory.CreateConnection();

        var result = new MensagemConsolidadoRequestDTO();
        var channel = connection.CreateModel();

        channel.QueueDeclare(_queue, exclusive: false);
        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, eventArgs) =>
        {
            var body = eventArgs.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine($"Mensagem recebida: {message}");

            result = JsonConvert.DeserializeObject<MensagemConsolidadoRequestDTO>(message);


            if (result.MessageId != Guid.Empty)
            {
                GravarConsolidadoCaixa(consolidadoService, result);
            }

        };

        channel.BasicConsume(queue: "consolidado", autoAck: true, consumer: consumer);

    }

    static void ConfigureService(IServiceCollection services)
    {
        var builder = new ConfigurationBuilder();
        builder.SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        var configuration = builder.Build();

        ConsolidadoInjector.Register(services, configuration);

    }
}

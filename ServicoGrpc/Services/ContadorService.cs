using Grpc.Core;
using gRPCContagem;
using ServicoGrpc;
using System.Reflection;
using System.Runtime.Versioning;

public class ContadorService : ContadorSvc.ContadorSvcBase
{
    private readonly ILogger<ContadorService> _logger;
    private static Contador _CONTADOR = new Contador();
    private static string _FRAMEWORK;
    private static string _LOCAL;

    static ContadorService()
    {
        _FRAMEWORK = Assembly
                    .GetEntryAssembly()?
                    .GetCustomAttribute<TargetFrameworkAttribute>()?
                    .FrameworkName;
        _LOCAL = Environment.MachineName;
    }
#pragma warning restore S3963 // "static" fields should be initialized inline
    public ContadorService(ILogger<ContadorService> logger)
    {
        _logger = logger;
    }
    public override Task<ContadorReply> GerarValor(
            ContadorRequest request, ServerCallContext context)
    {
         _CONTADOR.Incrementar();
            int valorAtual = _CONTADOR.ValorAtual;

            _logger.LogInformation($"Valor atual: {valorAtual}");

            return Task.FromResult(new ContadorReply
            {
                Mensagem = "Olá " + request.Name,
                ValorAtual = valorAtual,
                LocalSvc = _LOCAL,
                TargetFramework = _FRAMEWORK
            });
    }



}

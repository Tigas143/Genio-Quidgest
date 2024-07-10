using CSGenio.business;
using CSGenio.business.async;
using CSGenio.framework;
using CSGenio.persistence;
using Process = CSGenio.business.CSGenioAs_apr;

namespace DbAdmin.IntegrationTest
{

    [GenioProcessType("SUCCESS","Test Process Success")]
    [GenioProcessMode(ArrayS_modpro.E_INDIV_1)]
    public class TestSuccessProcess : GenioServerJob
    {       
        
        public override void Execute(PersistentSupport sp, User user)
        {
            this.SetResponse(new Response(StatusMessage.OK()));
        }
    }

    [GenioProcessType("ASYNC", "Test Async")]
    [GenioProcessMode(ArrayS_modpro.E_INDIV_1)]
    public class TestAsyncProcess : GenioServerJobAsync
    {

        public override async Task<string> ExecuteAsync(PersistentSupport sp, User user, Process process)
        {
            this.SetResponse(new Response(StatusMessage.OK()));
            return await Task.FromResult("");
        }
    }



}

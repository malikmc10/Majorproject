﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace ScotiaServiceReference
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ScotiaServiceReference.IFirstWebService")]
    public interface IFirstWebService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFirstWebService/Message", ReplyAction="http://tempuri.org/IFirstWebService/MessageResponse")]
        System.Threading.Tasks.Task<string> MessageAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFirstWebService/Verify", ReplyAction="http://tempuri.org/IFirstWebService/VerifyResponse")]
        System.Threading.Tasks.Task<bool> VerifyAsync(string name, string cardNum);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public interface IFirstWebServiceChannel : ScotiaServiceReference.IFirstWebService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public partial class FirstWebServiceClient : System.ServiceModel.ClientBase<ScotiaServiceReference.IFirstWebService>, ScotiaServiceReference.IFirstWebService
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);

        internal double CusFunds(string cardNum, double amnt)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-84BE9VJH\\SQLEXPRESS;Initial Catalog=EC2Milestone1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            
                con.Open();
                SqlCommand cmd = new SqlCommand("Update ScotiaCustomer set  AvaBalance=AvaBalance-" + amnt + ", Balance=Balance-" + amnt + " where CardNumber='" + cardNum + "'", con);
                 cmd.ExecuteNonQuery();
                 SqlCommand cmd2 = new SqlCommand("Select AvaBalance, Balance from ScotiaCustomer where CardNumber='" + cardNum + "'", con);
                SqlDataReader rdr2 = cmd2.ExecuteReader();

            //DataTable table = new DataTable();
            //table.Columns.Add("Available");
            // double ava = 0.0;
            //double bal;
            /*
            while (rdr.Read())
            {
                ava = Convert.ToDouble(rdr["AvaBalance"]);
                bal = Convert.ToDouble(rdr["Balance"]);
            }
            */
            double ava;
            double fin = amnt;
            while ( rdr2.Read())
                ava = Convert.ToDouble(rdr2["AvaBalance"]);

            return fin;
            
            
        }

        public FirstWebServiceClient() : 
                base(FirstWebServiceClient.GetDefaultBinding(), FirstWebServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IFirstWebService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public FirstWebServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(FirstWebServiceClient.GetBindingForEndpoint(endpointConfiguration), FirstWebServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public FirstWebServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(FirstWebServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public FirstWebServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(FirstWebServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public FirstWebServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<string> MessageAsync()
        {
            return base.Channel.MessageAsync();
        }
        
        public System.Threading.Tasks.Task<bool> VerifyAsync(string name, string cardNum)
        {
            return base.Channel.VerifyAsync(name, cardNum);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IFirstWebService))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IFirstWebService))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:53899/FirstWebService.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return FirstWebServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IFirstWebService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return FirstWebServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IFirstWebService);
        }

        internal string Message()
        {
            throw new NotImplementedException();
        }

        internal bool Verify(string name, string v2)
        {
            //getCardData g = new getCardData();
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-84BE9VJH\\SQLEXPRESS;Initial Catalog=EC2Milestone1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select First,Last,CardNumber from ScotiaCustomer where CardNumber ='" + v2 + "' and First ='" + name + "' ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmd.ExecuteNonQuery();
            //g.ScotiaCustomer = dt;
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        internal bool VerifyFunds(decimal amount, string cardNum)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-84BE9VJH\\SQLEXPRESS;Initial Catalog=EC2Milestone1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select AvaBalance, Balance from ScotiaCustomer where CardNumber='" + cardNum + "'", con);
                SqlDataReader rdr = cmd.ExecuteReader();

                //DataTable table = new DataTable();
                //table.Columns.Add("Available");
                decimal ava = 0.0m;
                double bal;
                while (rdr.Read())
                {
                    ava = Convert.ToDecimal(rdr["AvaBalance"]);
                    bal = Convert.ToDouble(rdr["Balance"]);
                }
                if (ava > amount)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }

        
        

        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IFirstWebService,
        }
    }
}

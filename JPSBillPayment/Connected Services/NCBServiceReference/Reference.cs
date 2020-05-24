﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Primitives;
using System;
using System.Data;

namespace NCBServiceReference
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="NCBServiceReference.ISecondService")]
    public interface ISecondService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecondService/Message", ReplyAction="http://tempuri.org/ISecondService/MessageResponse")]
        System.Threading.Tasks.Task<string> MessageAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecondService/Verify", ReplyAction="http://tempuri.org/ISecondService/VerifyResponse")]
        System.Threading.Tasks.Task<bool> VerifyAsync(string name, string cardNum);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecondService/VerifyFunds", ReplyAction="http://tempuri.org/ISecondService/VerifyFundsResponse")]
        System.Threading.Tasks.Task<bool> VerifyFundsAsync(float amount, string cardNum);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecondService/CusFunds", ReplyAction="http://tempuri.org/ISecondService/CusFundsResponse")]
        System.Threading.Tasks.Task<double> CusFundsAsync(string cardNum, double amnt);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public interface ISecondServiceChannel : NCBServiceReference.ISecondService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public partial class SecondServiceClient : System.ServiceModel.ClientBase<NCBServiceReference.ISecondService>, NCBServiceReference.ISecondService
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);

        internal bool VerifyFunds(decimal amount, string cardNum)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-84BE9VJH\\SQLEXPRESS;Initial Catalog=EC2Milestone1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select Balance from Customers where CardNum='" + cardNum + "'", con);
            SqlDataReader rdr = cmd.ExecuteReader();

            //DataTable table = new DataTable();
            //table.Columns.Add("Available");
            //double ava = 0.0;
            decimal bal = 0.0m;
            while (rdr.Read())
            {

                bal = Convert.ToDecimal(rdr["Balance"]);
            }



            if (bal  > amount)
            {
                return true;
            }
            return false;
        }

        internal bool Verify(string name, string cardNum)
        {
            //getCardData g = new getCardData();
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-84BE9VJH\\SQLEXPRESS;Initial Catalog=EC2Milestone1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select Name,CardNum from Customers where CardNum ='" + cardNum + "' and Name ='" + name + "' ", con);
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

        public SecondServiceClient() : 
                base(SecondServiceClient.GetDefaultBinding(), SecondServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_ISecondService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }

        internal double CusFunds(string cardNum, double amnt)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-84BE9VJH\\SQLEXPRESS;Initial Catalog=EC2Milestone1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update Customers set  Balance=Balance-" + amnt + " where CardNum='" + cardNum + "'", con);
            SqlDataReader rdr = cmd.ExecuteReader();

            //DataTable table = new DataTable();
            //table.Columns.Add("Available");
            double ava = 0.0;
            double bal = 0.0;
            while (rdr.Read())
            {

                bal = Convert.ToDouble(rdr["Balance"]);
            }

            return ava;
        }

        public SecondServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(SecondServiceClient.GetBindingForEndpoint(endpointConfiguration), SecondServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public SecondServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(SecondServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public SecondServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(SecondServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public SecondServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
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
        
        public System.Threading.Tasks.Task<bool> VerifyFundsAsync(float amount, string cardNum)
        {
            return base.Channel.VerifyFundsAsync(amount, cardNum);
        }
        
        public System.Threading.Tasks.Task<double> CusFundsAsync(string cardNum, double amnt)
        {
            return base.Channel.CusFundsAsync(cardNum, amnt);
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
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_ISecondService))
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
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_ISecondService))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:54964/SecondService.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return SecondServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_ISecondService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return SecondServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_ISecondService);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_ISecondService,
        }
    }
}
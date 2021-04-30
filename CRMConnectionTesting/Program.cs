﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMConnectionTesting
{
    // XRM Tooling Library Reference https://docs.microsoft.com/en-us/dotnet/api/?view=dynamics-xrmtooling-ce-9

    public class Program
    {
        public static void Main( string[] args )
        {
            Console.WriteLine( "Test 1: Connecting Using Service Proxy and Office365 Authentication" );
            OrganizationServiceProxyConnection MediabardCRMOrganizationServiceProxy = new OrganizationServiceProxyConnection()
            {
                UserName = Properties.Resources.DynamicsCRM_Mediabard_TestUserUsername,
                Password = Properties.Resources.DynamicsCRM_Mediabard_TestUserPassword,
                SoapOrgServiceUri = Properties.Resources.DynamicsCRM_OrganizationService
            };
            CRMConnectionTests.TestOrganizationServiceProxyConnection( MediabardCRMOrganizationServiceProxy );
            CRMConnectionTests.TestOrganizationServiceRetrieve( MediabardCRMOrganizationServiceProxy.Service );
            Console.WriteLine( "Test 1: Finished" + Environment.NewLine );

            Console.WriteLine( "Test 2: Connecting using CRM Service Client and OAuth Authentication" );
            CRMServiceClientConnection MediabardCRMServiceClient = new CRMServiceClientConnection()
            {
                UserName = Properties.Resources.DynamicsCRM_Mediabard_TestUserUsername,
                Url = Properties.Resources.DynamicsCRM_Mediabard_URL
            };
            CRMConnectionTests.TestCRMServiceClientConnection( MediabardCRMServiceClient );
            CRMConnectionTests.TestOrganizationServiceRetrieve( MediabardCRMServiceClient.Service );
            Console.WriteLine( "Test 2: Finished" + Environment.NewLine );

            do // https://stackoverflow.com/questions/5891538/listen-for-key-press-in-net-console-app
            {
                while( !Console.KeyAvailable )
                { }
            }
            while( Console.ReadKey( true ).Key != ConsoleKey.Escape );
        }

    }
}

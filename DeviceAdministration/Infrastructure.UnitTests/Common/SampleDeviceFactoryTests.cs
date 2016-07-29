﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Applications.RemoteMonitoring.Common.DeviceSchema;
using Microsoft.Azure.Devices.Applications.RemoteMonitoring.Common.Factory;
using Microsoft.Azure.Devices.Applications.RemoteMonitoring.Common.Models;
using Microsoft.Azure.Devices.Applications.RemoteMonitoring.DeviceAdmin.Infrastructure.BusinessLogic;
using Moq;
using Xunit;

namespace Microsoft.Azure.Devices.Applications.RemoteMonitoring.DeviceAdmin.Infrastructure.UnitTests.Common
{
    public class SampleDeviceFactoryTests
    {
        private ISecurityKeyGenerator _securityKeyGeneratorMock;

        public SampleDeviceFactoryTests()
        {
            _securityKeyGeneratorMock = (new Mock<ISecurityKeyGenerator>()).Object; 
        }

        [Fact]
        public void TestGetSampleSimulatedDevice()
        {
            //not null
            DeviceModel d = DeviceSchemaHelper.BuildDeviceStructure("test", true, null);

            Assert.NotNull(d);
            Assert.Equal("test", d.DeviceProperties.DeviceID);
            Assert.Equal("normal", d.DeviceProperties.DeviceState);
            Assert.Equal(null, d.DeviceProperties.HubEnabledState);

        }

        ~SampleDeviceFactoryTests() { }


        [Fact]
        public void TestGetSampleDevice()
        {
          
            Random randomnumber = new Random();
            SecurityKeys keys = _securityKeyGeneratorMock.CreateRandomKeys();
            DeviceModel d = SampleDeviceFactory.GetSampleDevice(randomnumber, keys);
            Assert.NotNull(d);
            Assert.NotNull(d.DeviceProperties);
            Assert.NotNull(d.DeviceProperties.DeviceID);
        }

        [Fact]
        public void TestGetDefaultDeviceNames()
        {
            List<String> s = SampleDeviceFactory.GetDefaultDeviceNames();
            Assert.NotNull(s);
        }
        

    }
}

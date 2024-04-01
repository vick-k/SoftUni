namespace SmartDevice.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Text;

    public class DeviceTests
    {
        Device device;

        [SetUp]
        public void Setup()
        {
            device = new(16);
        }

        [Test]
        public void Ctor_ShouldInitialize()
        {
            Device newDevice = new(32);

            Assert.That(newDevice, Is.Not.Null);
            Assert.That(newDevice.MemoryCapacity, Is.EqualTo(32));
            Assert.That(newDevice.AvailableMemory, Is.EqualTo(32));
            Assert.That(newDevice.Photos, Is.EqualTo(0));
            Assert.That(newDevice.Applications.Count, Is.EqualTo(0));
        }

        [Test]
        public void TakePhoto_SizeIsSmallerThanAvailableMemory_True()
        {
            device.TakePhoto(10);

            Assert.That(device.AvailableMemory, Is.EqualTo(6));
            Assert.That(device.Photos, Is.EqualTo(1));
            Assert.That(device.TakePhoto(6), Is.EqualTo(true));
        }

        [Test]
        public void TakePhoto_SizeIsBiggerThanAvailableMemory_False()
        {
            Assert.That(device.TakePhoto(32), Is.EqualTo(false));
            Assert.That(device.AvailableMemory, Is.EqualTo(16));
            Assert.That(device.Photos, Is.EqualTo(0));
        }

        [Test]
        public void InstallApp_SizeIsSmallerThanAvailableMemory_ReturnsMessage()
        {
            device.InstallApp("Project X", 8);

            Assert.That(device.AvailableMemory, Is.EqualTo(8));
            Assert.That(device.Applications.FirstOrDefault(a => a == "Project X"), Is.Not.Null);
            Assert.That(device.Applications.Count, Is.EqualTo(1));
            Assert.That(device.InstallApp("Project Z", 8), Is.EqualTo("Project Z is installed successfully. Run application?"));
        }

        [Test]
        public void InstallApp_SizeIsBiggerThanAvailableMemory_Throws()
        {
            Assert.Throws<InvalidOperationException>(() => device.InstallApp("Project V", 32));
            Assert.That(device.AvailableMemory, Is.EqualTo(16));
            Assert.That(device.Applications.Count, Is.EqualTo(0));
        }

        [Test]
        public void FormatDevice_Success()
        {
            device.TakePhoto(2);
            device.InstallApp("Project X", 3);
            device.InstallApp("Project Z", 4);

            device.FormatDevice();

            Assert.That(device.Photos, Is.EqualTo(0));
            Assert.That(device.Applications.Count, Is.EqualTo(0));
            Assert.That(device.AvailableMemory, Is.EqualTo(16));
        }

        [Test]
        public void GetDeviceStatus_NoApps_ReturnsMessage()
        {
            StringBuilder sb = new();
            sb.AppendLine($"Memory Capacity: 16 MB, Available Memory: 16 MB");
            sb.AppendLine($"Photos Count: 0");
            sb.AppendLine($"Applications Installed: ");

            Assert.That(device.GetDeviceStatus(), Is.EqualTo(sb.ToString().TrimEnd()));
        }

        [Test]
        public void GetDeviceStatus_HasAppsInstalled_ReturnsMessage()
        {
            device.InstallApp("App1", 1);
            device.InstallApp("App2", 1);
            device.TakePhoto(1);

            StringBuilder sb = new();
            sb.AppendLine($"Memory Capacity: 16 MB, Available Memory: 13 MB");
            sb.AppendLine($"Photos Count: 1");
            sb.AppendLine($"Applications Installed: App1, App2");

            Assert.That(device.GetDeviceStatus(), Is.EqualTo(sb.ToString().TrimEnd()));
        }
    }
}
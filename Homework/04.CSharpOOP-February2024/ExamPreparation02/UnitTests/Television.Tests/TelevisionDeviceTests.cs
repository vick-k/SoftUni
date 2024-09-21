namespace Television.Tests
{
    using NUnit.Framework;
    using System;
    public class TelevisionDeviceTests
    {
        private TelevisionDevice device;

        [SetUp]
        public void Setup()
        {
            device = new("Sony", 1200.5, 1920, 1080);
        }

        [Test]
        public void Ctor_ValidData_ShouldInitialize()
        {
            TelevisionDevice newDevice = new("LG", 1500, 1920, 1080);

            Assert.That(newDevice.Brand, Is.EqualTo("LG"));
            Assert.That(newDevice.Price, Is.EqualTo(1500));
            Assert.That(newDevice.ScreenWidth, Is.EqualTo(1920));
            Assert.That(newDevice.ScreenHeigth, Is.EqualTo(1080));
        }

        [Test]
        public void SwitchOn_SoundOn()
        {
            Assert.That(device.SwitchOn(), Is.EqualTo($"Cahnnel {device.CurrentChannel} - Volume {device.Volume} - Sound On"));
        }

        [Test]
        public void SwitchOn_SoundOff()
        {
            device.MuteDevice();

            Assert.That(device.SwitchOn(), Is.EqualTo($"Cahnnel {device.CurrentChannel} - Volume {device.Volume} - Sound Off"));
        }

        [Test]
        public void ChangeChannel_IncorrectChannel_Throws()
        {
            Assert.Throws<ArgumentException>(() => device.ChangeChannel(-1));
        }

        [Test]
        public void ChangeChannel_CorrectChannel()
        {
            device.ChangeChannel(3);

            Assert.That(device.CurrentChannel, Is.EqualTo(3));
        }

        [Test]
        public void VolumeChange_Up()
        {
            Assert.That(device.VolumeChange("UP", 20), Is.EqualTo($"Volume: 33"));
        }

        [Test]
        public void VolumeChange_Up_OutOfRange()
        {
            Assert.That(device.VolumeChange("UP", 90), Is.EqualTo($"Volume: 100"));
        }

        [Test]
        public void VolumeChange_Down()
        {
            Assert.That(device.VolumeChange("DOWN", 3), Is.EqualTo($"Volume: 10"));
        }

        [Test]
        public void VolumeChange_Down_OutOfRange()
        {
            Assert.That(device.VolumeChange("DOWN", 50), Is.EqualTo($"Volume: 0"));
        }

        [Test]
        public void MuteDevice_Mute()
        {
            device.MuteDevice();

            Assert.That(device.IsMuted, Is.EqualTo(true));
        }

        [Test]
        public void MuteDevice_UnMute()
        {
            device.MuteDevice();
            device.MuteDevice();

            Assert.That(device.IsMuted, Is.EqualTo(false));
        }

        [Test]
        public void ToStringTest()
        {
            Assert.That(device.ToString(), Is.EqualTo("TV Device: Sony, Screen Resolution: 1920x1080, Price 1200.5$"));
        }
    }
}
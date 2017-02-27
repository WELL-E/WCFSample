using System;
using System.Globalization;
using System.ServiceModel;
using System.Windows;
using WCF.Common;
using WCF.Contracts;

namespace WCF.Client
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window , ICallbackService
    {
        private ICalculatorService _calculatorService;

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            const string address = "net.pipe://localhost/47D33AEA-8024-431C-95D8-3285500CE0BF";

            //var binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
            //var ep = new EndpointAddress(address);

            //_calculatorService =
            //    ChannelFactory<ICalculatorService>.CreateChannel(
            //        binding, ep
            //    );

            var factory = new DuplexChannelFactory<ICalculatorService>(new InstanceContext(this),
                new NetNamedPipeBinding(NetNamedPipeSecurityMode.None),
                new EndpointAddress(address));
            _calculatorService = factory.CreateChannel();

            try
            {
                _calculatorService.SetVersion("0.0.0.1");
                string version;
                _calculatorService.GetVersion(out version);
                this.TbVersion.Text = version;
            }
            catch (Exception ex)
            {
                LogHelper.Debug(ex.Message);
            }
        }

        private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                this.TbAddValue.Text = _calculatorService.Add(Convert.ToDouble(this.TbAddLeft.Text), 
                    Convert.ToDouble(this.TbAddRight.Text)).ToString(CultureInfo.InvariantCulture);
                LogHelper.Debug(string.Format("{0}+{1}={2}", this.TbAddLeft.Text, this.TbAddRight.Text, this.TbAddValue.Text));
            }
            catch (Exception ex)
            {
                LogHelper.Debug(ex.Message);
            }
        }

        private void BtnSubtract_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                this.TbSubtractValue.Text = _calculatorService.Subtract(Convert.ToDouble(this.TbSubtractLleft.Text),
                    Convert.ToDouble(this.TbSubtractRight.Text)).ToString(CultureInfo.InvariantCulture);
                LogHelper.Debug(string.Format("{0}-{1}={2}", this.TbSubtractLleft.Text, this.TbSubtractRight.Text, this.TbSubtractValue.Text));
            }
            catch (Exception ex)
            {
                LogHelper.Debug(ex.Message);
            }
        }

        private void BtnMultiply_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                this.TbMultiplyValue.Text = _calculatorService.Multiply(Convert.ToDouble(this.TbMultiplyLeft.Text),
                    Convert.ToDouble(this.TbMultiplyRight.Text)).ToString(CultureInfo.InvariantCulture);
                LogHelper.Debug(string.Format("{0}*{1}={2}", this.TbMultiplyLeft.Text, this.TbMultiplyRight.Text, this.TbMultiplyValue.Text));
            }
            catch (Exception ex)
            {
                LogHelper.Debug(ex.Message);
            }
        }

        private void BtnDivide_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                this.TbDivideValue.Text = _calculatorService.Divide(Convert.ToDouble(this.TbDivideLeft.Text),
                    Convert.ToDouble(this.TbDivideRight.Text)).ToString(CultureInfo.InvariantCulture);
                LogHelper.Debug(string.Format("{0}/{1}={2}", this.TbDivideLeft.Text, this.TbDivideRight.Text, this.TbDivideValue.Text));
            }
            catch (Exception ex)
            {
                LogHelper.Debug(ex.Message);
            }
        }

        private void BtnTest_OnClick(object sender, RoutedEventArgs e)
        {
            //_calculatorService.TestDelegate(TestCallBack);

            //byte[] data;
            //_calculatorService.TestBytes(out data);
            //TestCallBack(data);

            //var result = await _calculatorService.TestTask();
            //MessageBox.Show(result);

            _calculatorService.TestNotify();
        }

        private void TestCallBack(byte[] bytes)
        {
            foreach (var b in bytes)
            {
                TbTest.Text += b.ToString();
                TbTest.Text += ",";
            }
        }

        public void NotifyClient(string msg)
        {
            MessageBox.Show(msg);
        }
    }
}

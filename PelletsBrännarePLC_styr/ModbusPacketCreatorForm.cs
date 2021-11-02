using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PelletsBrännarePLC_styr
{
    public partial class ModbusPacketCreatorForm : Form
    {
        public Action<string> SendPacket;

        public ModbusPacketCreatorForm()
        {
            InitializeComponent();
        }

        private void btnGenerateModbusPacket_Click(object sender, EventArgs e)
        {
            GenerateModbusPacket();
        }

        private void btnSendModbusPacket_Click(object sender, EventArgs e)
        {
            SendPacket(txtBoxModbusGeneratedPacket.Text.Replace("\\r\\n", "\r\n"));
        }

        private void radBtnModbusReadWrite_CheckedChanged(object sender, EventArgs e)
        {
            if (radBtnModbusRead.Checked)
            {
                txtBoxModbusData.Enabled = false;
                txtBoxModbusDataCount.Enabled = true;
            }
            else
            {
                txtBoxModbusData.Enabled = true;
                txtBoxModbusDataCount.Enabled = false;
            }
        }

        private void GenerateModbusPacket()
        {
            string data = txtBoxModbusDeviceAddress.Text;
            if (radBtnModbusRead.Checked)
                data += "03";
            else
                data += "10";
            data += txtBoxModbusAddress.Text;
            if (radBtnModbusWrite.Checked)
            {

                if (txtBoxModbusData.Text.Length % 2 != 0)
                {
                    txtBoxModbusDataCount.Text = "??";
                    return;
                }
                txtBoxModbusDataCount.Text = (txtBoxModbusData.Text.Length / 2).ToString("x2");
                data += txtBoxModbusDataCount.Text;
                data += txtBoxModbusData.Text;
            }
            else
                data += txtBoxModbusDataCount.Text;

            byte[] dataBytes = null;
            try
            {
                if (!data.ConvertFromByteAsciiHex(0, data.Length, out dataBytes))
                {

                    txtBoxModbusGeneratedPacket.Text = "error while convert >>>" + data + "<<< to byte-array (verify that there are only hex chars)";
                    return;
                }
                data += dataBytes.Calculate_LR_Checksum().ToString("x2").ToUpper();

                txtBoxModbusGeneratedPacket.Text = ":" + data + "\\r\\n";
            }
            catch (Exception ex)
            {
                txtBoxModbusGeneratedPacket.Text = ex.ToString();

            }

        }

        private void ModbusPacketCreatorForm_VisibleChanged(object sender, EventArgs e)
        {
            SetSendAvailableState(this.Visible && (SendPacket != null));
        }

        private void SetSendAvailableState(bool sendActive)
        {
            btnSendModbusPacket.Enabled = sendActive;
            lblWarningDelegateNotSet.Visible = !sendActive;
        }

        private void ModbusPacketCreatorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.Visible = false;
                e.Cancel = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}

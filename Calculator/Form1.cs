using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class frmCalculator : Form
    {
        double value = 0;
        string operation = null;
        bool operation_pressed = false;
        double varM = 0;
        
        public frmCalculator()
        {
            InitializeComponent();
        }

        /// clicking numbers
        private void btnOne_Click(object sender, EventArgs e)
        {
            CheckStep(btnOne);
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            CheckStep(btnTwo);
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            CheckStep(btnThree);
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            CheckStep(btnZero);
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            CheckStep(btnFour);
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            CheckStep(btnFive);
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            CheckStep(btnSix);
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            CheckStep(btnSeven);
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            CheckStep(btnEight);
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            CheckStep(btnNine);
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            CheckStep(btnDot);
        }


        /// clicking operators
        private void btnClear_Click(object sender, EventArgs e)
        {
            tbResult.Clear();
            tbPreview.Clear();
            value = 0;
            operation_pressed = false;
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            CheckOperations(btnPlus);
            //forPercentage(btnPlus);
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            CheckOperations(btnMinus);
            //forPercentage(btnMinus);
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            CheckOperations(btnMultiply);
            //forPercentage(btnMultiply);
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            CheckOperations(btnDivide);
            //forPercentage(btnDivide);
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            tbPreview.Text = "";
            switch (operation)
            {
                case "+":
                    tbResult.Text = (value + double.Parse(tbResult.Text)).ToString();
                    break;
                case "-":
                    tbResult.Text = (value - double.Parse(tbResult.Text)).ToString();
                    break;
                case "/":
                    tbResult.Text = (value / double.Parse(tbResult.Text)).ToString();
                    break;
                case "x":
                    tbResult.Text = (value * double.Parse(tbResult.Text)).ToString();
                    break;
  //              case "%":
    //                tbResult.Text = ((value * 0.01) * double.Parse(tbResult.Text)).ToString();
      //              break;
                default:
                    break;
            }
            operation_pressed = false;
            value = double.Parse(tbResult.Text);
            operation = null;
        }

        /// methods
        private void CheckStep(Button btn)
        {
            if ((tbResult.Text == "0") || (operation_pressed == true))
            {
                tbResult.Clear();
                operation_pressed = false;
            }

            if (btn.Text==",")
            {
                if (!tbResult.Text.Contains(","))
                {
                    tbResult.Text = tbResult.Text + btn.Text;
                }
            }
            else
            {
                tbResult.Text = tbResult.Text + btn.Text;
            }
        }

        private void CheckOperations(Button btnOperation)
        {
            try
            {
                 if (value != 0)  
                 {
                     if (btnOperation.Text == "%") 
                     {
                         tbResult.Text = (double.Parse(tbResult.Text) / 100).ToString();
                         value = double.Parse(tbResult.Text) / 100;      
                     }
                     btnResult.PerformClick(); // натрупва стойността във value
                     operation_pressed = true;
                     operation = btnOperation.Text;
                     tbPreview.Text = value + " " + operation;
                     tbResult.Text = "";
                 }
                 else if (btnOperation.Text == "%") // help from internet
                 {
                     tbResult.Text = (double.Parse(tbResult.Text) / 100).ToString();
                     value = double.Parse(tbResult.Text) / 100;
                     /* if (tbPreview.Text.Contains("%"))
                     {
                         string str = tbPreview.Text;
                         str = str.Replace('%', '+');
                         tbPreview.Text = str;
                     } */
                 }  
                 else
                 {
                     operation = btnOperation.Text;
                     value = double.Parse(tbResult.Text);
                     operation_pressed = true;
                     tbPreview.Text = value + " " + operation;
                 }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                tbPreview.Text = value + " " + operation;
            }
        }

        private void frmCalculator_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar.ToString())
            {
                case "0":
                    btnZero.PerformClick();
                    break;
                case "1":
                    btnOne.PerformClick();
                    break;
                case "2":
                    btnTwo.PerformClick();
                    break;
                case "3":
                    btnThree.PerformClick();
                    break;
                case "4":
                    btnFour.PerformClick();
                    break;
                case "5":
                    btnFive.PerformClick();
                    break;
                case "6":
                    btnSix.PerformClick();
                    break;
                case "7":
                    btnSeven.PerformClick();
                    break;
                case "8":
                    btnEight.PerformClick();
                    break;
                case "9":
                    btnNine.PerformClick();
                    break;
                case "+":
                    btnPlus.PerformClick();
                    break;
                case "-":
                    btnMinus.PerformClick();
                    break;
                case "/":
                    btnDivide.PerformClick();
                    break;
                case "x":
                    btnMultiply.PerformClick();
                    break;
                default:
                    break;
            }
        }




        // more operators
        private void btnPercent_Click(object sender, EventArgs e)
        {
                CheckOperations(btnPercent);
        } 

        private void btnMPlus_Click(object sender, EventArgs e)
        {
            if (tbResult.Text != "0" && tbResult.Text != "")
            {   
                btnMR.Enabled = true;
                varM = varM + double.Parse(tbResult.Text);
                lblTest.Text = varM.ToString();
            }
            else
            {
                MessageBox.Show("Въведете първо стойност за да я запаметите в memory паметта.");
                btnMR.Enabled = false;
            }      
        }

        private void btnMMinus_Click(object sender, EventArgs e)
        {
            if (tbResult.Text != "0" && tbResult.Text != "")
            {
                btnMR.Enabled = true;
                varM = varM - double.Parse(tbResult.Text);
                lblTest.Text = varM.ToString();//
            }
            else
            {
                MessageBox.Show("Въведете първо стойност за да я запаметите в memory паметта.");
                btnMR.Enabled = false;
            }      
        }

        private void btnMC_Click(object sender, EventArgs e)
        {
            varM = 0;
            btnMR.Enabled = false;
            lblTest.Text = "0";
        }

        private void btnMR_Click(object sender, EventArgs e)
        {
            if (varM!=0)
            {
                tbResult.Text = varM.ToString();
            }
            else 
            {
                btnMR.Enabled = false;
            }         
        }

        private void frmCalculator_Load(object sender, EventArgs e)
        {
                btnMR.Enabled = false;    
        }  
    }
}

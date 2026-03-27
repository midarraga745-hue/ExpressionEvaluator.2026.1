using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;
using ExpressionEvaluator.Core;

namespace ExpressionEvaluator.UI.Win;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    // Numbers
    private void btn7_Click(object sender, EventArgs e)
    {
        txtDisplay.Text += "7";
    }

    private void btn8_Click(object sender, EventArgs e)
    {
        txtDisplay.Text += "8";
    }

    private void btn9_Click(object sender, EventArgs e)
    {
        txtDisplay.Text += "9";
    }

    private void btn4_Click(object sender, EventArgs e)
    {
        txtDisplay.Text += "4";
    }

    private void btn5_Click(object sender, EventArgs e)
    {
        txtDisplay.Text += "5";
    }

    private void btn6_Click(object sender, EventArgs e)
    {
        txtDisplay.Text += "6";
    }

    private void btn1_Click(object sender, EventArgs e)
    {
        txtDisplay.Text += "1";
    }

    private void btn2_Click(object sender, EventArgs e)
    {
        txtDisplay.Text += "2";
    }

    private void btn3_Click(object sender, EventArgs e)
    {
        txtDisplay.Text += "3";
    }

    private void btn0_Click(object sender, EventArgs e)
    {
        txtDisplay.Text += "0";
    }

    // Decimal point
    private void btnDot_Click(object sender, EventArgs e)
    {
        txtDisplay.Text += ".";
    }

    // Operators
    private void btnPlus_Click(object sender, EventArgs e)
    {
        txtDisplay.Text += "+";
    }

    private void btnMinus_Click(object sender, EventArgs e)
    {
        txtDisplay.Text += "-";
    }

    private void btnMultiply_Click(object sender, EventArgs e)
    {
        txtDisplay.Text += "*";
    }

    private void btnDivide_Click(object sender, EventArgs e)
    {
        txtDisplay.Text += "/";
    }

    private void btnPow_Click(object sender, EventArgs e)
    {
        txtDisplay.Text += "^";
    }

    // Parenthesis
    private void btnOpenParenthesis_Click(object sender, EventArgs e)
    {
        txtDisplay.Text += "(";
    }

    private void btnCloseParenthesis_Click(object sender, EventArgs e)
    {
        txtDisplay.Text += ")";
    }

    // Delete last character
    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (txtDisplay.Text.Length > 0)
            txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1);
    }

    // Clean everything
    private void btnClear_Click(object sender, EventArgs e)
    {
        txtDisplay.Text = "";
    }

    // Calculate result
    private void btnResult_Click(object sender, EventArgs e)
    {
        try
        {
            string expresion = txtDisplay.Text;

            // Multiplication (2)(3)
            expresion = Regex.Replace(expresion, @"\)\(", ")*(");

            // Power 2^3
            while (Regex.IsMatch(expresion, @"(\d+(\.\d+)?)\^(\d+(\.\d+)?)"))
            {
                expresion = Regex.Replace(expresion,
                    @"(\d+(\.\d+)?)\^(\d+(\.\d+)?)",
                    m =>
                    {
                        double baseNum = double.Parse(m.Groups[1].Value, CultureInfo.InvariantCulture);
                        double expNum = double.Parse(m.Groups[3].Value, CultureInfo.InvariantCulture);
                        double res = Math.Pow(baseNum, expNum);
                        return res.ToString(CultureInfo.InvariantCulture);
                    });
            }
            expresion = Regex.Replace(expresion, @"(\d+)\^(\d+)", "Pow($1,$2)");

            var result = new System.Data.DataTable().Compute(expresion, null);
            double numero = Convert.ToDouble(result, CultureInfo.InvariantCulture);

            txtDisplay.Text = numero.ToString("G", CultureInfo.InvariantCulture);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            txtDisplay.Text = "Error";
        }
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        txtDisplay = new TextBox();
        btn7 = new Button();
        btn8 = new Button();
        btn9 = new Button();
        btnDivide = new Button();
        btnMultiply = new Button();
        btnDelete = new Button();
        btn4 = new Button();
        btn5 = new Button();
        btn6 = new Button();
        btnPlus = new Button();
        btnMinus = new Button();
        btnClear = new Button();
        btn1 = new Button();
        btn2 = new Button();
        btn3 = new Button();
        btnOpenParenthesis = new Button();
        btnCloseParenthesis = new Button();
        btnPow = new Button();
        btn0 = new Button();
        btnDot = new Button();
        btnResult = new Button();
        SuspendLayout();
        //
        // txtDisplay
        //
        txtDisplay.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtDisplay.BackColor = Color.FromArgb(0, 64, 0);
        txtDisplay.ForeColor = Color.White;
        txtDisplay.Location = new Point(38, 27);
        txtDisplay.Name = "txtDisplay";
        txtDisplay.Size = new Size(382, 27);
        txtDisplay.TabIndex = 0;
        //
        // btn7
        //
        btn7.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
        btn7.Location = new Point(38, 78);
        btn7.Name = "btn7";
        btn7.Size = new Size(52, 44);
        btn7.TabIndex = 1;
        btn7.Text = "7";
        btn7.UseVisualStyleBackColor = true;
        btn7.Click += btn7_Click;
        //
        // btn8
        //
        btn8.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
        btn8.Location = new Point(101, 78);
        btn8.Name = "btn8";
        btn8.Size = new Size(52, 44);
        btn8.TabIndex = 2;
        btn8.Text = "8";
        btn8.UseVisualStyleBackColor = true;
        btn8.Click += btn8_Click;
        //
        // btn9
        //
        btn9.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
        btn9.Location = new Point(164, 78);
        btn9.Name = "btn9";
        btn9.Size = new Size(52, 44);
        btn9.TabIndex = 3;
        btn9.Text = "9";
        btn9.UseVisualStyleBackColor = true;
        btn9.Click += btn9_Click;
        //
        // btnDivide
        //
        btnDivide.BackColor = Color.FromArgb(192, 64, 0);
        btnDivide.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
        btnDivide.Location = new Point(227, 78);
        btnDivide.Name = "btnDivide";
        btnDivide.Size = new Size(52, 49);
        btnDivide.TabIndex = 4;
        btnDivide.Text = "/";
        btnDivide.UseVisualStyleBackColor = false;
        btnDivide.Click += btnDivide_Click;
        //
        // btnMultiply
        //
        btnMultiply.BackColor = Color.FromArgb(192, 64, 0);
        btnMultiply.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
        btnMultiply.Location = new Point(290, 78);
        btnMultiply.Name = "btnMultiply";
        btnMultiply.Size = new Size(52, 49);
        btnMultiply.TabIndex = 5;
        btnMultiply.Text = "*";
        btnMultiply.UseVisualStyleBackColor = false;
        btnMultiply.Click += btnMultiply_Click;
        //
        // btnDelete
        //
        btnDelete.BackColor = Color.FromArgb(192, 64, 0);
        btnDelete.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        btnDelete.ForeColor = Color.Black;
        btnDelete.Location = new Point(353, 78);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new Size(67, 44);
        btnDelete.TabIndex = 6;
        btnDelete.Text = "Delete";
        btnDelete.UseVisualStyleBackColor = false;
        btnDelete.Click += btnDelete_Click;
        //
        // btn4
        //
        btn4.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
        btn4.Location = new Point(38, 133);
        btn4.Name = "btn4";
        btn4.Size = new Size(52, 44);
        btn4.TabIndex = 7;
        btn4.Text = "4";
        btn4.UseVisualStyleBackColor = true;
        btn4.Click += btn4_Click;
        //
        // btn5
        //
        btn5.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
        btn5.Location = new Point(101, 133);
        btn5.Name = "btn5";
        btn5.Size = new Size(52, 44);
        btn5.TabIndex = 8;
        btn5.Text = "5";
        btn5.UseVisualStyleBackColor = true;
        btn5.Click += btn5_Click;
        //
        // btn6
        //
        btn6.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
        btn6.Location = new Point(164, 133);
        btn6.Name = "btn6";
        btn6.Size = new Size(52, 44);
        btn6.TabIndex = 9;
        btn6.Text = "6";
        btn6.UseVisualStyleBackColor = true;
        btn6.Click += btn6_Click;
        //
        // btnPlus
        //
        btnPlus.BackColor = Color.FromArgb(192, 64, 0);
        btnPlus.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
        btnPlus.Location = new Point(227, 133);
        btnPlus.Name = "btnPlus";
        btnPlus.Size = new Size(52, 49);
        btnPlus.TabIndex = 10;
        btnPlus.Text = "+";
        btnPlus.UseVisualStyleBackColor = false;
        btnPlus.Click += btnPlus_Click;
        //
        // btnMinus
        //
        btnMinus.BackColor = Color.FromArgb(192, 64, 0);
        btnMinus.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
        btnMinus.Location = new Point(290, 133);
        btnMinus.Name = "btnMinus";
        btnMinus.Size = new Size(52, 49);
        btnMinus.TabIndex = 11;
        btnMinus.Text = "-";
        btnMinus.UseVisualStyleBackColor = false;
        btnMinus.Click += btnMinus_Click;
        //
        // btnClear
        //
        btnClear.BackColor = Color.FromArgb(192, 64, 0);
        btnClear.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        btnClear.Location = new Point(353, 133);
        btnClear.Name = "btnClear";
        btnClear.Size = new Size(67, 49);
        btnClear.TabIndex = 12;
        btnClear.Text = "Clear";
        btnClear.UseVisualStyleBackColor = false;
        btnClear.Click += btnClear_Click;
        //
        // btn1
        //
        btn1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
        btn1.Location = new Point(38, 188);
        btn1.Name = "btn1";
        btn1.Size = new Size(52, 44);
        btn1.TabIndex = 13;
        btn1.Text = "1";
        btn1.UseVisualStyleBackColor = true;
        btn1.Click += btn1_Click;
        //
        // btn2
        //
        btn2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
        btn2.Location = new Point(101, 188);
        btn2.Name = "btn2";
        btn2.Size = new Size(52, 44);
        btn2.TabIndex = 14;
        btn2.Text = "2";
        btn2.UseVisualStyleBackColor = true;
        btn2.Click += btn2_Click;
        //
        // btn3
        //
        btn3.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
        btn3.Location = new Point(164, 188);
        btn3.Name = "btn3";
        btn3.Size = new Size(52, 44);
        btn3.TabIndex = 15;
        btn3.Text = "3";
        btn3.UseVisualStyleBackColor = true;
        btn3.Click += btn3_Click;
        //
        // btnOpenParenthesis
        //
        btnOpenParenthesis.BackColor = Color.FromArgb(192, 64, 0);
        btnOpenParenthesis.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
        btnOpenParenthesis.Location = new Point(227, 188);
        btnOpenParenthesis.Name = "btnOpenParenthesis";
        btnOpenParenthesis.Size = new Size(52, 49);
        btnOpenParenthesis.TabIndex = 16;
        btnOpenParenthesis.Text = "(";
        btnOpenParenthesis.UseVisualStyleBackColor = false;
        btnOpenParenthesis.Click += btnOpenParenthesis_Click;
        //
        // btnCloseParenthesis
        //
        btnCloseParenthesis.BackColor = Color.FromArgb(192, 64, 0);
        btnCloseParenthesis.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
        btnCloseParenthesis.Location = new Point(290, 188);
        btnCloseParenthesis.Name = "btnCloseParenthesis";
        btnCloseParenthesis.Size = new Size(52, 49);
        btnCloseParenthesis.TabIndex = 17;
        btnCloseParenthesis.Text = ")";
        btnCloseParenthesis.UseVisualStyleBackColor = false;
        btnCloseParenthesis.Click += btnCloseParenthesis_Click;
        //
        // btnPow
        //
        btnPow.BackColor = Color.FromArgb(192, 64, 0);
        btnPow.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
        btnPow.Location = new Point(353, 188);
        btnPow.Name = "btnPow";
        btnPow.Size = new Size(67, 49);
        btnPow.TabIndex = 18;
        btnPow.Text = "^";
        btnPow.UseVisualStyleBackColor = false;
        btnPow.Click += btnPow_Click;
        //
        // btn0
        //
        btn0.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
        btn0.Location = new Point(38, 243);
        btn0.Name = "btn0";
        btn0.Size = new Size(52, 44);
        btn0.TabIndex = 19;
        btn0.Text = "0";
        btn0.UseVisualStyleBackColor = true;
        btn0.Click += btn0_Click;
        //
        // btnDot
        //
        btnDot.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
        btnDot.Location = new Point(101, 243);
        btnDot.Name = "btnDot";
        btnDot.Size = new Size(52, 44);
        btnDot.TabIndex = 20;
        btnDot.Text = ".";
        btnDot.UseVisualStyleBackColor = true;
        btnDot.Click += btnDot_Click;
        //
        // btnResult
        //
        btnResult.BackColor = Color.FromArgb(192, 64, 0);
        btnResult.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
        btnResult.Location = new Point(164, 243);
        btnResult.Name = "btnResult";
        btnResult.Size = new Size(256, 44);
        btnResult.TabIndex = 21;
        btnResult.Text = "=";
        btnResult.UseVisualStyleBackColor = false;
        btnResult.Click += btnResult_Click;
        //
        // Form1
        //
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.Black;
        ClientSize = new Size(450, 320);
        Controls.Add(txtDisplay);
        Controls.Add(btn7);
        Controls.Add(btn8);
        Controls.Add(btn9);
        Controls.Add(btnDivide);
        Controls.Add(btnMultiply);
        Controls.Add(btnDelete);
        Controls.Add(btn4);
        Controls.Add(btn5);
        Controls.Add(btn6);
        Controls.Add(btnPlus);
        Controls.Add(btnMinus);
        Controls.Add(btnClear);
        Controls.Add(btn1);
        Controls.Add(btn2);
        Controls.Add(btn3);
        Controls.Add(btnOpenParenthesis);
        Controls.Add(btnCloseParenthesis);
        Controls.Add(btnPow);
        Controls.Add(btn0);
        Controls.Add(btnDot);
        Controls.Add(btnResult);
        Name = "Form1";
        Text = "Functions Evaluator";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion Windows Form Designer generated code

    private TextBox txtDisplay;
    private Button btn7, btn8, btn9;
    private Button btnDivide, btnMultiply, btnDelete;
    private Button btn4, btn5, btn6;
    private Button btnPlus, btnMinus, btnClear;
    private Button btn1, btn2, btn3;
    private Button btnOpenParenthesis, btnCloseParenthesis, btnPow;
    private Button btn0, btnDot, btnResult;
}
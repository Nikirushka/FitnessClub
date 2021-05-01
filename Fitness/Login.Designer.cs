namespace Fitness
{
    partial class Вход
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Вход));
            this.label1 = new System.Windows.Forms.Label();
            this.EnterButton = new Guna.UI.WinForms.GunaButton();
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.LoginTextBox = new Guna.UI.WinForms.GunaTextBox();
            this.gunaElipse2 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.gunaButton1 = new Guna.UI.WinForms.GunaButton();
            this.gunaDragControl1 = new Guna.UI.WinForms.GunaDragControl(this.components);
            this.gunaDragControl2 = new Guna.UI.WinForms.GunaDragControl(this.components);
            this.PasswordTextBox = new Guna.UI.WinForms.GunaTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(40)))));
            this.label1.Location = new System.Drawing.Point(0, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(363, 38);
            this.label1.TabIndex = 2;
            this.label1.Text = "Вход";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // EnterButton
            // 
            this.EnterButton.Animated = true;
            this.EnterButton.AnimationHoverSpeed = 0.07F;
            this.EnterButton.AnimationSpeed = 0.03F;
            this.EnterButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(40)))));
            this.EnterButton.BorderColor = System.Drawing.Color.Black;
            this.EnterButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EnterButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.EnterButton.FocusedColor = System.Drawing.Color.Empty;
            this.EnterButton.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnterButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(197)))), ((int)(((byte)(56)))));
            this.EnterButton.Image = null;
            this.EnterButton.ImageSize = new System.Drawing.Size(20, 20);
            this.EnterButton.Location = new System.Drawing.Point(36, 164);
            this.EnterButton.Name = "EnterButton";
            this.EnterButton.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.EnterButton.OnHoverBorderColor = System.Drawing.Color.Black;
            this.EnterButton.OnHoverForeColor = System.Drawing.Color.White;
            this.EnterButton.OnHoverImage = null;
            this.EnterButton.OnPressedColor = System.Drawing.Color.Black;
            this.EnterButton.Size = new System.Drawing.Size(294, 42);
            this.EnterButton.TabIndex = 3;
            this.EnterButton.Text = "Войти";
            this.EnterButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.EnterButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.Radius = 10;
            this.gunaElipse1.TargetControl = this;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 20.25F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(40)))));
            this.label2.Location = new System.Drawing.Point(333, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 35);
            this.label2.TabIndex = 5;
            this.label2.Text = "X";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            this.label2.MouseEnter += new System.EventHandler(this.label2_MouseEnter);
            this.label2.MouseLeave += new System.EventHandler(this.label2_MouseLeave);
            // 
            // LoginTextBox
            // 
            this.LoginTextBox.BackColor = System.Drawing.Color.Transparent;
            this.LoginTextBox.BaseColor = System.Drawing.Color.White;
            this.LoginTextBox.BorderColor = System.Drawing.Color.Silver;
            this.LoginTextBox.BorderSize = 1;
            this.LoginTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.LoginTextBox.FocusedBaseColor = System.Drawing.Color.White;
            this.LoginTextBox.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.LoginTextBox.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.LoginTextBox.Font = new System.Drawing.Font("Trebuchet MS", 15.75F);
            this.LoginTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(40)))));
            this.LoginTextBox.Location = new System.Drawing.Point(36, 64);
            this.LoginTextBox.Name = "LoginTextBox";
            this.LoginTextBox.PasswordChar = '\0';
            this.LoginTextBox.Radius = 7;
            this.LoginTextBox.Size = new System.Drawing.Size(294, 35);
            this.LoginTextBox.TabIndex = 1;
            this.LoginTextBox.Text = "Логин";
            this.LoginTextBox.Click += new System.EventHandler(this.LoginTextBox_Click);
            this.LoginTextBox.Enter += new System.EventHandler(this.LoginTextBox_Click);
            // 
            // gunaElipse2
            // 
            this.gunaElipse2.Radius = 10;
            this.gunaElipse2.TargetControl = this.EnterButton;
            // 
            // gunaButton1
            // 
            this.gunaButton1.Animated = true;
            this.gunaButton1.AnimationHoverSpeed = 0.07F;
            this.gunaButton1.AnimationSpeed = 0.03F;
            this.gunaButton1.BackColor = System.Drawing.Color.Transparent;
            this.gunaButton1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(40)))));
            this.gunaButton1.BorderColor = System.Drawing.Color.Black;
            this.gunaButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gunaButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaButton1.FocusedColor = System.Drawing.Color.Empty;
            this.gunaButton1.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gunaButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(197)))), ((int)(((byte)(56)))));
            this.gunaButton1.Image = null;
            this.gunaButton1.ImageSize = new System.Drawing.Size(20, 20);
            this.gunaButton1.Location = new System.Drawing.Point(36, 212);
            this.gunaButton1.Name = "gunaButton1";
            this.gunaButton1.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.gunaButton1.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaButton1.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaButton1.OnHoverImage = null;
            this.gunaButton1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaButton1.Radius = 7;
            this.gunaButton1.Size = new System.Drawing.Size(294, 42);
            this.gunaButton1.TabIndex = 0;
            this.gunaButton1.Text = "Создать новый аккаунт";
            this.gunaButton1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.gunaButton1.Click += new System.EventHandler(this.gunaButton1_Click);
            // 
            // gunaDragControl1
            // 
            this.gunaDragControl1.TargetControl = this;
            // 
            // gunaDragControl2
            // 
            this.gunaDragControl2.TargetControl = this.label1;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.BackColor = System.Drawing.Color.Transparent;
            this.PasswordTextBox.BaseColor = System.Drawing.Color.White;
            this.PasswordTextBox.BorderColor = System.Drawing.Color.Silver;
            this.PasswordTextBox.BorderSize = 1;
            this.PasswordTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.PasswordTextBox.FocusedBaseColor = System.Drawing.Color.White;
            this.PasswordTextBox.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.PasswordTextBox.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.PasswordTextBox.Font = new System.Drawing.Font("Trebuchet MS", 15.75F);
            this.PasswordTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(40)))));
            this.PasswordTextBox.Location = new System.Drawing.Point(35, 116);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Radius = 7;
            this.PasswordTextBox.Size = new System.Drawing.Size(294, 35);
            this.PasswordTextBox.TabIndex = 2;
            this.PasswordTextBox.Text = "Пароль";
            this.PasswordTextBox.Enter += new System.EventHandler(this.PasswordTextBox_Click);
            // 
            // Вход
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(197)))), ((int)(((byte)(56)))));
            this.ClientSize = new System.Drawing.Size(364, 266);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.gunaButton1);
            this.Controls.Add(this.LoginTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.EnterButton);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Вход";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Вход";
            this.Load += new System.EventHandler(this.Вход_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaButton EnterButton;
        private Guna.UI.WinForms.GunaElipse gunaElipse1;
        private System.Windows.Forms.Label label2;
        private Guna.UI.WinForms.GunaTextBox LoginTextBox;
        private Guna.UI.WinForms.GunaElipse gunaElipse2;
        private Guna.UI.WinForms.GunaButton gunaButton1;
        private Guna.UI.WinForms.GunaDragControl gunaDragControl1;
        private Guna.UI.WinForms.GunaDragControl gunaDragControl2;
        private Guna.UI.WinForms.GunaTextBox PasswordTextBox;
    }
}


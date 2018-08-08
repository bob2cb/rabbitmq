namespace TestRabbitMQ
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_producer = new System.Windows.Forms.Button();
            this.button_RecieveMessageWithGet = new System.Windows.Forms.Button();
            this.button_send = new System.Windows.Forms.Button();
            this.button_initConsumer = new System.Windows.Forms.Button();
            this.button_AckMessageWithGet = new System.Windows.Forms.Button();
            this.button_AckMessageWithSubscribe = new System.Windows.Forms.Button();
            this.button_RecieveMessageWithSubscribe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_producer
            // 
            this.button_producer.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_producer.Location = new System.Drawing.Point(12, 12);
            this.button_producer.Name = "button_producer";
            this.button_producer.Size = new System.Drawing.Size(300, 58);
            this.button_producer.TabIndex = 0;
            this.button_producer.Text = "InitProducer";
            this.button_producer.UseVisualStyleBackColor = true;
            this.button_producer.Click += new System.EventHandler(this.button_producer_Click);
            // 
            // button_RecieveMessageWithGet
            // 
            this.button_RecieveMessageWithGet.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_RecieveMessageWithGet.Location = new System.Drawing.Point(12, 176);
            this.button_RecieveMessageWithGet.Name = "button_RecieveMessageWithGet";
            this.button_RecieveMessageWithGet.Size = new System.Drawing.Size(300, 58);
            this.button_RecieveMessageWithGet.TabIndex = 1;
            this.button_RecieveMessageWithGet.Text = "RecieveMessageWithGet";
            this.button_RecieveMessageWithGet.UseVisualStyleBackColor = true;
            this.button_RecieveMessageWithGet.Click += new System.EventHandler(this.button_RecieveMessageWithGet_Click);
            // 
            // button_send
            // 
            this.button_send.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_send.Location = new System.Drawing.Point(329, 12);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(256, 58);
            this.button_send.TabIndex = 2;
            this.button_send.Text = "SendMessage";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // button_initConsumer
            // 
            this.button_initConsumer.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_initConsumer.Location = new System.Drawing.Point(12, 95);
            this.button_initConsumer.Name = "button_initConsumer";
            this.button_initConsumer.Size = new System.Drawing.Size(573, 58);
            this.button_initConsumer.TabIndex = 3;
            this.button_initConsumer.Text = "InitConsumer";
            this.button_initConsumer.UseVisualStyleBackColor = true;
            this.button_initConsumer.Click += new System.EventHandler(this.button_initConsumer_Click);
            // 
            // button_AckMessageWithGet
            // 
            this.button_AckMessageWithGet.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_AckMessageWithGet.Location = new System.Drawing.Point(329, 176);
            this.button_AckMessageWithGet.Name = "button_AckMessageWithGet";
            this.button_AckMessageWithGet.Size = new System.Drawing.Size(256, 58);
            this.button_AckMessageWithGet.TabIndex = 4;
            this.button_AckMessageWithGet.Text = "AckMessageWithGet";
            this.button_AckMessageWithGet.UseVisualStyleBackColor = true;
            this.button_AckMessageWithGet.Click += new System.EventHandler(this.button_AckMessageWithGet_Click);
            // 
            // button_AckMessageWithSubscribe
            // 
            this.button_AckMessageWithSubscribe.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_AckMessageWithSubscribe.Location = new System.Drawing.Point(329, 254);
            this.button_AckMessageWithSubscribe.Name = "button_AckMessageWithSubscribe";
            this.button_AckMessageWithSubscribe.Size = new System.Drawing.Size(256, 58);
            this.button_AckMessageWithSubscribe.TabIndex = 6;
            this.button_AckMessageWithSubscribe.Text = "AckMessageWithSubscribe";
            this.button_AckMessageWithSubscribe.UseVisualStyleBackColor = true;
            this.button_AckMessageWithSubscribe.Click += new System.EventHandler(this.button_AckMessageWithSubscribe_Click);
            // 
            // button_RecieveMessageWithSubscribe
            // 
            this.button_RecieveMessageWithSubscribe.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_RecieveMessageWithSubscribe.Location = new System.Drawing.Point(12, 254);
            this.button_RecieveMessageWithSubscribe.Name = "button_RecieveMessageWithSubscribe";
            this.button_RecieveMessageWithSubscribe.Size = new System.Drawing.Size(300, 58);
            this.button_RecieveMessageWithSubscribe.TabIndex = 5;
            this.button_RecieveMessageWithSubscribe.Text = "RecieveMessageWithSubscribe";
            this.button_RecieveMessageWithSubscribe.UseVisualStyleBackColor = true;
            this.button_RecieveMessageWithSubscribe.Click += new System.EventHandler(this.button_RecieveMessageWithSubscribe_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 346);
            this.Controls.Add(this.button_AckMessageWithSubscribe);
            this.Controls.Add(this.button_RecieveMessageWithSubscribe);
            this.Controls.Add(this.button_AckMessageWithGet);
            this.Controls.Add(this.button_initConsumer);
            this.Controls.Add(this.button_send);
            this.Controls.Add(this.button_RecieveMessageWithGet);
            this.Controls.Add(this.button_producer);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_producer;
        private System.Windows.Forms.Button button_RecieveMessageWithGet;
        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.Button button_initConsumer;
        private System.Windows.Forms.Button button_AckMessageWithGet;
        private System.Windows.Forms.Button button_AckMessageWithSubscribe;
        private System.Windows.Forms.Button button_RecieveMessageWithSubscribe;
    }
}


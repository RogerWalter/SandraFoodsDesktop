namespace SistemaClientes
{
    partial class PosicaoMotoboy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PosicaoMotoboy));
            this.gMap = new GMap.NET.WindowsForms.GMapControl();
            this.btCancelar = new System.Windows.Forms.PictureBox();
            this.btCentralizar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btCentralizar)).BeginInit();
            this.SuspendLayout();
            // 
            // gMap
            // 
            this.gMap.Bearing = 0F;
            this.gMap.CanDragMap = true;
            this.gMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMap.GrayScaleMode = false;
            this.gMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMap.LevelsKeepInMemmory = 5;
            this.gMap.Location = new System.Drawing.Point(12, 12);
            this.gMap.MarkersEnabled = true;
            this.gMap.MaxZoom = 18;
            this.gMap.MinZoom = 2;
            this.gMap.MouseWheelZoomEnabled = true;
            this.gMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMap.Name = "gMap";
            this.gMap.NegativeMode = false;
            this.gMap.PolygonsEnabled = true;
            this.gMap.RetryLoadTile = 0;
            this.gMap.RoutesEnabled = true;
            this.gMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMap.ShowTileGridLines = false;
            this.gMap.Size = new System.Drawing.Size(805, 483);
            this.gMap.TabIndex = 0;
            this.gMap.Zoom = 18D;
            // 
            // btCancelar
            // 
            this.btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCancelar.Image = global::SistemaClientes.Properties.Resources.Cancelar;
            this.btCancelar.Location = new System.Drawing.Point(761, 501);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(56, 52);
            this.btCancelar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btCancelar.TabIndex = 32;
            this.btCancelar.TabStop = false;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btCentralizar
            // 
            this.btCentralizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCentralizar.Image = global::SistemaClientes.Properties.Resources.btMotoboyMapa;
            this.btCentralizar.Location = new System.Drawing.Point(12, 501);
            this.btCentralizar.Name = "btCentralizar";
            this.btCentralizar.Size = new System.Drawing.Size(56, 52);
            this.btCentralizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btCentralizar.TabIndex = 32;
            this.btCentralizar.TabStop = false;
            this.btCentralizar.Click += new System.EventHandler(this.btCentralizar_Click);
            // 
            // PosicaoMotoboy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(829, 565);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btCentralizar);
            this.Controls.Add(this.gMap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PosicaoMotoboy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Posição do Motoboy";
            this.Load += new System.EventHandler(this.PosicaoMotoboy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btCentralizar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMap;
        private System.Windows.Forms.PictureBox btCentralizar;
        private System.Windows.Forms.PictureBox btCancelar;
    }
}
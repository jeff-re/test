using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Itse1430.MovieLib.Host
{
    public partial class MovieForm : Form
    {
        public MovieForm ()
        {
            InitializeComponent();
        }

        //Must be a property...
        public Movie Movie { get; set; }

        protected override void OnLoad ( EventArgs e )
        {
            //Call base type
            //OnLoad(e);
            base.OnLoad(e);

            if (Movie != null)
            {
                _txtName.Text = Movie.Title;
                txtDescription.Text = Movie.Description;
                _txtReleaseYear.Text = Movie.ReleaseYear.ToString();
                _txtRunLength.Text = Movie.RunLength.ToString();
                cbRating.Text = Movie.Rating;
                chkHasSeen.Checked = Movie.HasSeen;
            };
        }

        private void OnSave ( object sender, EventArgs e )
        {
            var movie = new Movie();
            //movie.set_title(_txtName.Text);
            movie.Title = _txtName.Text;
            movie.Description = txtDescription.Text;
            movie.ReleaseYear = GetAsInt32(_txtReleaseYear);
            movie.RunLength = GetAsInt32(_txtRunLength);
            movie.Rating = cbRating.Text;
            movie.HasSeen = chkHasSeen.Checked;

            //Validate
            var message = movie.Validate();
            if (!String.IsNullOrEmpty(message))
                return;  //TODO: Error

            //TODO: Save it
            Movie = movie;

            DialogResult = DialogResult.OK;
            Close();
        }

        private int GetAsInt32 ( TextBox control )
        {
            if (Int32.TryParse(control.Text, out var result))
                return result;

            return 0;
        }

        private void BtnCancel_Click ( object sender, EventArgs e )
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

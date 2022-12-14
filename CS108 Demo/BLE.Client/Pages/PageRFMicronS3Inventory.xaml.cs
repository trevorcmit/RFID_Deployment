using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace BLE.Client.Pages {
    [ContentProperty (nameof(Source))]
    public class ImageResourceExtension : IMarkupExtension {
        public string Source { get; set; }
        public object ProvideValue (IServiceProvider serviceProvider) {
            if (Source == null) return null;

            // Do your translation lookup here, using whatever method you require
            var imageSource = ImageSource.FromResource(Source);
            return imageSource;
        }

    }
    
    public partial class PageRFMicroS3Inventory {
		public PageRFMicroS3Inventory() {
			InitializeComponent();
        }

    }
}

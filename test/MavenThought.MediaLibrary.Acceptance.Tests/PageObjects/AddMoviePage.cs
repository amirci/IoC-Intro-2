using System;
using MavenThought.MediaLibrary.Acceptance.Tests.Utility;

namespace MavenThought.MediaLibrary.Acceptance.Tests.PageObjects
{
    /// <summary>
    /// Page to abstract add movies page implementation on the web application
    /// </summary>
    public class AddMoviePage
    {
        /// <summary>
        /// Gets or sets the title in the add movies page
        /// </summary>
        public string Title
        {
            get { return Browser.Instance.TextField("Title").Value; }
            
            set { Browser.Instance.TextField("Title").Value = value; }
        }

        /// <summary>
        /// Clicks on the submit button to submit the form
        /// </summary>
        public void Submit()
        {
            Browser.Instance.Button("Submit").Click();
        }
    }
}
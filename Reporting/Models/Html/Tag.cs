
namespace Reporting.Models.Html
{
    public class Tag : HtmlTagBase
    {
        #region Constructors
        
        /// <summary>
        /// Default constructor for xml serialization
        /// </summary>
        public Tag()
        {

        }

        /// <summary>
        /// Creates an c# object version of an html tag.
        /// </summary>
        /// <param name="name">The name of the html tag.</param>
        public Tag(string name)
        {
            _tag = name;
        }

        #endregion Constructors

        #region Methods

        

        #endregion Methods
    }
}

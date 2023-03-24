using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows;

namespace veryRichTextBox
{
    public class BlogPost
    {
        string _subjectLine;
        string _bodyText;
        Color _subjectColor;
        DateTime _timeStampe;


        public BlogPost(string subjectLine, string bodyText, Color userColor)
        {
            _subjectLine = subjectLine;
            _bodyText = bodyText;
            _subjectColor= userColor;
            _timeStampe = DateTime.Now; 
        }

        public string SubkectLine { get => _subjectLine; set => _subjectLine = value; }
        public string BodyText { get => _bodyText; set => _bodyText = value; }

        public Run HeaderFormatted(string subjectLine)
        {
            Run headerRun = new Run(subjectLine);
            headerRun.Foreground = new SolidColorBrush(_subjectColor);//usercolor
            headerRun.FontSize = 24;//font
            headerRun.FontStyle = FontStyles.Oblique;

            return headerRun;
        }
        //body formatted
        public Run BodyFormatted(string bodyText)
        {
            Run runNewBody = new Run(bodyText);
            runNewBody.FontSize = 16;//body font size

            return runNewBody;
        }

        public Paragraph BlogPostFormatted()
        {
            //get the flow document
            //create a paragraph
            Paragraph newParagraph = new Paragraph();

            //create a run
            string subjectLine = _subjectLine;
            string bodyText = _bodyText;

            Run header = HeaderFormatted(subjectLine);
            Run body = BodyFormatted(bodyText);

            //add to paragrph
            newParagraph.Inlines.Add(header);
            newParagraph.Inlines.Add("\n");
            newParagraph.Inlines.Add(body);

            //SubjectLine
            //new Line
            //body Text

            return newParagraph;

        }



        public override string ToString()
        {
            return _timeStampe.ToShortTimeString() + " " + _subjectLine;
        }

    }//BlogPost
}//namespace

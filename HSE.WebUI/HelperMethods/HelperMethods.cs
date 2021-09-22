using System;

namespace HSE.WebUI.HelperMethods
{
    public static class HelperMethods
    {
        public static int GetLineNumber(Exception ex)
        {
            var lineNumber = 0;
            const string lineSearch = ":line ";
            if (ex.StackTrace != null)
            {
                var index = ex.StackTrace.LastIndexOf(lineSearch, StringComparison.Ordinal);
                if (index != -1)
                {
                    var lineNumberText = ex.StackTrace.Substring(index + lineSearch.Length);
                    if (int.TryParse(lineNumberText, out lineNumber))
                    {
                    }
                }
            }
            return lineNumber;
        }

        public static void IfExistDeletePhoto(string filePath)
        {
            if (filePath != null)
            {
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }
        }
    }
}

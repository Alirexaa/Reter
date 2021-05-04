using System;

namespace Reter.Domain.Blog.ArticleCategoryAgg.Exceptions
{
    public class DuplicatedRecordException:Exception
    {
        public DuplicatedRecordException()
        {
            
        }

        public DuplicatedRecordException(string message):base(message)
        {
            
        }
    }
}
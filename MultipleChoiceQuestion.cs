using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_quiz_by_harneet
{
    public class MultipleChoiceQuestion:Question
    {
        
        private List<string> list1;
        
        public MultipleChoiceQuestion( List<string> l1)
        {
            
            this.list1 = l1;
            
        }
}

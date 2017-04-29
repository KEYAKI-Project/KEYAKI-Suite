using System.Linq;
using HtmlAgilityPack;

namespace AgilityExtension
{
    public static class AgilityExtension
    {
        public static HtmlNode ChindSelectByClass(this HtmlNode node, string className)
        {
            return node.ChildNodes.Single(htmlNode => htmlNode.GetAttributeValue("class", "") == className);
        }
    }
}

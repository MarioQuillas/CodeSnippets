namespace Dixin.Linq.CSharp
{
    using System.Linq.Expressions;

    internal class PrefixVisitor : BinaryArithmeticExpressionVisitor<string>
    {
        protected override string VisitAdd
            (BinaryExpression add, LambdaExpression expression) => this.VisitBinary(add, "add", expression);

        protected override string VisitConstant
            (ConstantExpression constant, LambdaExpression expression) => constant.Value.ToString();

        protected override string VisitDivide
            (BinaryExpression divide, LambdaExpression expression) => this.VisitBinary(divide, "div", expression);

        protected override string VisitMultiply
            (BinaryExpression multiply, LambdaExpression expression) =>
            this.VisitBinary(multiply, "mul", expression);

        protected override string VisitParameter
            (ParameterExpression parameter, LambdaExpression expression) => parameter.Name;

        protected override string VisitSubtract
            (BinaryExpression subtract, LambdaExpression expression) =>
            this.VisitBinary(subtract, "sub", expression);

        private string VisitBinary( // Recursion: operator(left, right)
            BinaryExpression binary, string @operator, LambdaExpression expression) =>
            $"{@operator}({this.VisitNode(binary.Left, expression)}, {this.VisitNode(binary.Right, expression)})";
    }
}
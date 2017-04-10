namespace Dixin.Linq.CSharp
{
    using System;
    using System.Linq.Expressions;

    internal abstract class BinaryArithmeticExpressionVisitor<TResult>
    {
        internal TResult VisitBody(LambdaExpression expression) => this.VisitNode(expression.Body, expression);

        protected TResult VisitNode(Expression node, LambdaExpression expression)
        {
            // Processes the 6 types of node.
            switch (node.NodeType)
            {
                case ExpressionType.Add:
                    return this.VisitAdd((BinaryExpression)node, expression);

                case ExpressionType.Constant:
                    return this.VisitConstant((ConstantExpression)node, expression);

                case ExpressionType.Divide:
                    return this.VisitDivide((BinaryExpression)node, expression);

                case ExpressionType.Multiply:
                    return this.VisitMultiply((BinaryExpression)node, expression);

                case ExpressionType.Parameter:
                    return this.VisitParameter((ParameterExpression)node, expression);

                case ExpressionType.Subtract:
                    return this.VisitSubtract((BinaryExpression)node, expression);

                default:
                    throw new ArgumentOutOfRangeException(nameof(node));
            }
        }

        protected abstract TResult VisitAdd(BinaryExpression add, LambdaExpression expression);

        protected abstract TResult VisitConstant(ConstantExpression constant, LambdaExpression expression);

        protected abstract TResult VisitDivide(BinaryExpression divide, LambdaExpression expression);

        protected abstract TResult VisitMultiply(BinaryExpression multiply, LambdaExpression expression);

        protected abstract TResult VisitParameter(ParameterExpression parameter, LambdaExpression expression);

        protected abstract TResult VisitSubtract(BinaryExpression subtract, LambdaExpression expression);
    }
}
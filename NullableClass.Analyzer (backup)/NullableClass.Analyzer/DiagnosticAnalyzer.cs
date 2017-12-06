using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Text;

namespace NullableClass.Analyzer
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class NullableClassAnalyzer : DiagnosticAnalyzer
	{
		private static readonly DiagnosticDescriptor LiteralNullRule = new DiagnosticDescriptor
			(
				id: "NULL01",
				title: "Null is forbidden",
				messageFormat: "NULL value is not supported for class types.",
				category: "Usage",
				defaultSeverity: DiagnosticSeverity.Error,
				isEnabledByDefault: true,
				description: "Null is forbidden"
			);

		private static readonly DiagnosticDescriptor NullFieldRule = new DiagnosticDescriptor
			(
				id: "NULL02",
				title: "Field needs initializer",
				messageFormat: "Field {0} needs a non-null initial value.",
				category: "Usage",
				defaultSeverity: DiagnosticSeverity.Error,
				isEnabledByDefault: true,
				description: "Field needs initializer"
			);

		private static readonly DiagnosticDescriptor NullPropertyRule = new DiagnosticDescriptor
			(
				id: "NULL03",
				title: "Property needs initializer",
				messageFormat: "Property {0} needs a non-null initial value.",
				category: "Usage",
				defaultSeverity: DiagnosticSeverity.Error,
				isEnabledByDefault: true,
				description: "Property needs initializer"
			);

		private static readonly DiagnosticDescriptor EmptyArrayRule = new DiagnosticDescriptor
			(
				id: "NULL04",
				title: "Can't create empty array",
				messageFormat: "Empty array of class type is not supported. Try declaring it nullable or calling Default<T>.NewArray()",
				category: "Usage",
				defaultSeverity: DiagnosticSeverity.Error,
				isEnabledByDefault: true,
				description: "Can't create empty array"
			);

		public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(LiteralNullRule, NullFieldRule, NullPropertyRule, EmptyArrayRule);

		public override void Initialize(AnalysisContext context)
		{
			// See https://github.com/dotnet/roslyn/blob/master/docs/analyzers/Analyzer%20Actions%20Semantics.md for more information
			context.RegisterSyntaxNodeAction(AnalyzeNullOrDefault, SyntaxKind.NullLiteralExpression, SyntaxKind.DefaultExpression);
			context.RegisterSyntaxNodeAction(AnalyzeField, SyntaxKind.FieldDeclaration);
			context.RegisterSyntaxNodeAction(AnalyzeProperty, SyntaxKind.PropertyDeclaration);
			context.RegisterSyntaxNodeAction(AnalyzeArray, SyntaxKind.ArrayCreationExpression);
		}

		private void AnalyzeArray(SyntaxNodeAnalysisContext context)
		{
			var array = (ArrayCreationExpressionSyntax)context.Node;

			if (array.Initializer != null) return;

			var typeInfo = context.SemanticModel.GetTypeInfo(array.Type.ElementType);
			var typeSymbol = typeInfo.ConvertedType;

			if (typeSymbol.IsValueType) return;

			context.ReportDiagnostic(Diagnostic.Create(EmptyArrayRule, context.Node.GetLocation()));
		}

		private void AnalyzeProperty(SyntaxNodeAnalysisContext context)
		{
			var property = (PropertyDeclarationSyntax)context.Node;

			var typeInfo = context.SemanticModel.GetTypeInfo(property.Type);
			var typeSymbol = typeInfo.ConvertedType;

			if (typeSymbol.IsValueType) return;

			if (property.ExpressionBody != null) return;

			if (property.AccessorList.Accessors.Any(x => x.Body != null)) return;

			try
			{
				if (property.AccessorList.Accessors.Any(x => ((dynamic)x).ExpressionBody != null)) return;
			}
			catch { }

			if (property.Initializer != null) return;

			context.ReportDiagnostic(Diagnostic.Create(NullFieldRule, context.Node.GetLocation(), property.Identifier.Text));
		}

		private void AnalyzeField(SyntaxNodeAnalysisContext context)
		{
			var field = (FieldDeclarationSyntax)context.Node;
			foreach (var variable in field.Declaration.Variables)
			{
				var initializer = variable.Initializer;

				if (initializer != null) continue;

				var typeInfo = context.SemanticModel.GetTypeInfo(field.Declaration.Type);
				var typeSymbol = typeInfo.ConvertedType;

				if (typeSymbol.IsValueType) continue;

				context.ReportDiagnostic(Diagnostic.Create(NullFieldRule, context.Node.GetLocation(), variable.Identifier.Text));
			}
		}

		private void AnalyzeNullOrDefault(SyntaxNodeAnalysisContext context)
		{
			try
			{
				var expression = (ExpressionSyntax)context.Node;
				var typeInfo = context.SemanticModel.GetTypeInfo(expression);
				var typeSymbol = typeInfo.ConvertedType;

				if (typeSymbol.IsValueType) return;

				context.ReportDiagnostic(Diagnostic.Create(LiteralNullRule, context.Node.GetLocation()));
			}
			catch { }
		}
	}
}

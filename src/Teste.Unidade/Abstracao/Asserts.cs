using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MPSC.PlenoSoft.PlenoControle.Teste.Unidade.Abstracao
{
	public static class Asserts
	{
		public static Exception Throws<TException>(Action action, Boolean acceptSubType = false) where TException : Exception
		{
			var exceptionType = typeof(TException);
			try
			{
				action();
			}
			catch (TException exception) when (acceptSubType || exception.GetType().Equals(exceptionType))
			{
				return exception;
			}
			catch (Exception ex)
			{
				var mensagem = $"Deveria ter lançado uma exceção do tipo '{exceptionType.FullName}' mas lançou uma do tipo " +
					$"'{ex.GetType().FullName}' com a mensagem: '{ex.Message}'; InnerException: {ex.InnerException.Messages(" -> ")};";

				throw new AssertFailedException(mensagem, ex);
			}

			throw new AssertFailedException($"Deveria ter lançado exceção do tipo '{exceptionType.FullName}', mas lançou nenhuma!");
		}


		public static String Messages(this Exception exception, String join)
		{
			return String.Join(join, AllMessages(exception));
		}

		public static IEnumerable<String> AllMessages(this Exception exception)
		{
			while (exception != null)
			{
				yield return exception.Message;
				exception = exception.InnerException;
			}
		}
	}
}
using System;

namespace MPSC.PlenoSoft.PlenoControle.Teste.Unidade.Abstracao
{
	public static class Asserts
	{
		public static Exception Throws<T>(Action p) where T : Exception
		{
			try
			{
				p();
			}
			catch (T ex)
			{
				return ex;
			}
			catch (Exception ex)
			{
				return ex;
			}
			return null;
		}
	}
}
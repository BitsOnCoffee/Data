using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitsOnCoffee.Data.StoredProcedures
{
	public abstract class StoredProcedureBase
	{
		#region Parameters
		public IDictionary<string, object> Parameters
		{
			get
			{
				return _parameters;
			}
		}
		protected IDictionary<string, object> _parameters; 
		#endregion

		#region StoredProcedureBase (ctor)
		public StoredProcedureBase()
		{
			_parameters = new Dictionary<string, object>();
		} 
		#endregion

		#region AddParameter
		public void AddParameter<T>(string name, T value)
		{
			_parameters.Add(string.Format("@{0}", name), value);
		} 
		#endregion
	}
}

using System.ComponentModel.DataAnnotations;

namespace BitsOnCoffee.Data
{
	/// <summary>
	/// Abstract base class for entities.
	/// </summary>
	public abstract class EntityBase
	{
		/// <summary>
		/// Not saved Entity Id.
		/// </summary>
		public const long BUSINESS_EMPTY_ID = 0;

		/// <summary>
		/// Id of Entity.
		/// </summary>
		[Key]
		[ScaffoldColumn(false)]
		public long Id { get; set; }

		/// <summary>
		/// True if the entity has not been stored in the data storage yet.
		/// </summary>
		public bool IsNew { get { return this.Id == BUSINESS_EMPTY_ID; } }

		#region GetEntityName
		/// <summary>
		/// Returns entity logical name (class name without namespace).
		/// </summary>
		public string GetEntityName()
		{
			return this.GetType().Name;
		}
		#endregion

		#region Equals (override) and == and != operators
		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (obj is EntityBase)
			{
				EntityBase objEntity = (EntityBase)obj;
				return this.Id == objEntity.Id;
			}
			return false;
		}
		public static bool operator ==(EntityBase a, EntityBase b)
		{
			if (((object)a != null) && ((object)b != null))
			{
				return a.Equals(b);
			}
			else if (((object)a == null) && ((object)b == null))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public static bool operator !=(EntityBase a, EntityBase b)
		{
			return !(a == b);
		}
		#endregion

		#region override GetHashCode
		public override int GetHashCode()
		{
			return this.Id.GetHashCode();
		}
		#endregion

		#region override ToString
		public override string ToString()
		{
			if (this.IsNew)
			{
				return string.Format("{0}, Id: Not stored yet", GetType().FullName);
			}
			else
			{
				return string.Format("{0}, Id: {1}", GetType().FullName, this.Id);
			}
		}
		#endregion
	}
}

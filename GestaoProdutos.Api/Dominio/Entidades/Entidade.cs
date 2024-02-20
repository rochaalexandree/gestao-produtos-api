using Flunt.Notifications;
using System;
using System.Diagnostics.Contracts;

namespace GestaoProdutos.Dominio.Entidades
{
    public abstract class Entidade : Notifiable<Notification>
    {
        public Guid Id { get; set; }
        public bool Modificada { get; set; } = false;

        protected Entidade()
        {
            Id = Guid.NewGuid();
        }

        #region Comparações

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entidade;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entidade a, Entidade b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entidade a, Entidade b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 309) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}]";
        }

        #endregion
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;

namespace Pe.ByS.ERP.Cross.Core.Extension
{
    /// <summary>
    /// Clase estatica de extensiones
    /// </summary>
    /// <remarks>
    /// Creación:       BYS 20140310 <br />
    /// Modificación:                <br />
    /// </remarks>
    public static class Extension
    {
        /// <summary>
        /// Método que permite listar una tabla
        /// </summary>
        /// <returns> tabla </returns>
        public static DataTable ToDataTable<T>(this IList<T> data)
        {

            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));

            DataTable table = new DataTable();

            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                Type type = Nullable.GetUnderlyingType(prop.PropertyType);
                type = (type == null) ? prop.PropertyType : type;
                table.Columns.Add(prop.Name, type);
            }

            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }

            return table;
        }

        /// <summary>
        /// Extensión para obtener un valor de un diccionario.
        /// </summary>
        /// <typeparam name="TKey">Tipo de la llave de búsqueda</typeparam>
        /// <typeparam name="TValue">Tipo del valor a devolver</typeparam>
        /// <param name="data">Diccionario en el cual se buscará</param>
        /// <param name="llave">Llave para la búsqueda</param>
        /// <returns>Objecto correspondiente a la llave</returns>
        public static TValue GetValue<TKey, TValue>(this IDictionary<TKey, TValue> data, TKey llave)
        {
            TValue valor;

            data.TryGetValue(llave, out valor);

            return valor;
        }

        /// <summary>
        /// Extensión para setar un valor en un diccionario.
        /// </summary>
        /// <typeparam name="TKey">Tipo de la llave</typeparam>
        /// <typeparam name="TValue">Tipo del valor a setear</typeparam>
        /// <param name="data">Diccionario en el cual se buscará</param>
        /// <param name="llave">Llave para la búsqueda</param>
        /// <param name="valor">valor a setear</param>
        public static void SetValue<TKey, TValue>(this IDictionary<TKey, TValue> data, TKey llave, TValue valor)
        {
            if (data.Any(d => d.Key.Equals(llave)))
            {
                data[llave] = valor;
            }
            else
            {
                data.Add(llave, valor);
            }
        }
    }
}
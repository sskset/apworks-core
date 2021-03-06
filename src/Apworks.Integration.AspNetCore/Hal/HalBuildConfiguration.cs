﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Hal.Builders;

namespace Apworks.Integration.AspNetCore.Hal
{
    public class HalBuildConfiguration : ICollection<HalBuildConfigurationItem>, IHalBuildConfiguration
    {
        private readonly List<HalBuildConfigurationItem> items = new List<HalBuildConfigurationItem>();

        public HalBuildConfiguration() { }

        public HalBuildConfiguration(IEnumerable<HalBuildConfigurationItem> items)
        {
            this.items.AddRange(items);
        }

        /// <summary>
        /// Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        public int Count => this.items.Count;

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only.
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <param name="item">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
        public void Add(HalBuildConfigurationItem item) => this.items.Add(item);

        /// <summary>
        /// Clears the items in the current collection.
        /// </summary>
        public void Clear() => this.items.Clear();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(HalBuildConfigurationItem item) => this.items.Contains(item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(HalBuildConfigurationItem[] array, int arrayIndex) => this.items.CopyTo(array, arrayIndex);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<HalBuildConfigurationItem> GetEnumerator() => this.items.GetEnumerator();

        public void RegisterHalBuilderFactory(ControllerActionSignature signature, Func<HalBuildContext, IBuilder> halBuilderFactory)
        {
            if (this.items.Any(item => item.Signature == signature))
            {
                return;
            }

            this.items.Add(new HalBuildConfigurationItem(signature, halBuilderFactory));
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
        /// <returns>
        /// true if <paramref name="item" /> was successfully removed from the <see cref="T:System.Collections.Generic.ICollection`1" />; otherwise, false. This method also returns false if <paramref name="item" /> is not found in the original <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </returns>
        public bool Remove(HalBuildConfigurationItem item) => this.items.Remove(item);

        public Func<HalBuildContext, IBuilder> RetrieveHalBuilderFactory(ControllerActionSignature signature)
        {
            var item = this.items.FirstOrDefault(x => x.Signature == signature);
            if (item == null)
            {
                return null;
            }

            return item.HalBuilderFactory;
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator() => this.items.GetEnumerator();
    }
}

﻿using Demo.Domain.Inventory.Items.Events;
using NServiceBus;
using Raven.Client;

namespace Demo.Application.RavenDB.Inventory.Items
{
    public class EventHandler : IHandleMessages<Created>, IHandleMessages<DescriptionChanged>
    {
        private readonly IDocumentStore _store;

        public EventHandler(IDocumentStore store)
        {
            _store = store;
        }

        public void Handle(Created e)
        {
            var account = new Item
            {
                Id = e.ItemId,
                Number = e.Number,
                Description = e.Description,
                UnitOfMeasure = e.UnitOfMeasure,
                CatalogPrice = e.CatalogPrice,
                CostPrice = e.CostPrice,
            };

            using (IDocumentSession session = _store.OpenSession())
            {
                session.Store(account);
                session.SaveChanges();
            }
        }

        public void Handle(DescriptionChanged e)
        {
            using (IDocumentSession session = _store.OpenSession())
            {
                var item = session.Load<Item>(e.ItemId);
                item.Description = e.Description;
                session.Store(item);
                session.SaveChanges();
            }
        }
    }
}
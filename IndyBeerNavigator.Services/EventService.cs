using IndyBeerNavigator.Data;
using IndyBeerNavigator.Data.Entities;
using IndyBeerNavigator.Models.EventModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndyBeerNavigator.Services
{
    public class EventService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        // CREATE
        public bool CreateEvent (EventCreate model)
        {
            var entity = new Event
            {
                EventId = model.EventId,
                Type = model.Type,
                Description = model.Description,
                EventDate = model.EventDate,
                BreweryId = model.BreweryId,
                Brewery = model.Brewery
            };

            _context.Events.Add(entity);
            return _context.SaveChanges() == 1;
        }

        // GET ALL
        public List<EventListItem> GetAllBeers()
        {
            var eventEntities = _context.Events.ToList();
            var eventList = eventEntities.Select(b => new EventListItem
            {
                EventId = b.EventId,
                Type = b.Type,
                Description = b.Description,
                EventDate = b.EventDate,
                BreweryId = b.BreweryId,
                Brewery = b.Brewery
            }).ToList();
            return eventList;
        }

        // GET (Details by Id)
        public EventDetail GetEventById(int eventId)
        {
            var eventEntity = _context.Events.Find(eventId);
            if (eventEntity == null)
                return null;

            var eventDetail = new EventDetail
            {
                EventId = eventEntity.EventId,
                Type = eventEntity.Type,
                Description = eventEntity.Description,
                EventDate = eventEntity.EventDate,
                BreweryId = eventEntity.BreweryId,
                Brewery = eventEntity.Brewery
            };
            return eventDetail;
        }

        // UPDATE
        public bool UpdateEvent(EventEdit model)
        {
            var eventEntity = _context.Events.Find(model.EventId);

            eventEntity.EventId = model.EventId;
            eventEntity.Type = model.Type;
            eventEntity.Description = model.Description;
            eventEntity.EventDate = model.EventDate;
            eventEntity.BreweryId = model.BreweryId;

            return _context.SaveChanges() == 1;
        }

        // DELETE
        public bool DeleteEvent(int eventId)
        {
            var entity = _context.Events.Find(eventId);

            _context.Events.Remove(entity);

            return _context.SaveChanges() == 1;
        }
    }
}


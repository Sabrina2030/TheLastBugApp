﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLastBug.Business.DTOs;
using TheLastBug.Business.Interfaces;
using TheLastBug.Domain.Contexts.AutoGenerated;
using TheLastBug.Domain.Models;

namespace TheLastBug.Business.Services
{
    public class LogService : ILogService
    {
        private readonly TheLastBugContext context;
        private readonly ILogger logger;
        private readonly IMapper _mapper;

        public LogService(TheLastBugContext context, ILogger<LogService> logger, IMapper mapper)
        {
            this.context = context;
            this.logger = logger;
            this._mapper = mapper;
        }

        public async Task LogUserAction(int userId, string accion)
        {

            try
            {
                var log = new Log
                {
                    UserId = userId,
                    Accion = accion,
                    FechaHora = DateTime.Now
                };

                context.Logs.Add(log);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al registrar el log de la actividad.");
                throw;
            }
        }

        public async Task<List<LogDTO>> GetLogsByDate(DateTime fecha)
        {
            var logs = await context.Logs
            .Where(l => l.FechaHora.Date == fecha.Date)
            .ToListAsync();

            return _mapper.Map<List<LogDTO>>(logs);
        }
    }
}

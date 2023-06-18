using Ejyle.DevAccelerate.Core.Data;
using Ejyle.DevAccelerate.Mail;
using Ejyle.DevAccelerate.Mail.SendGrid;
using Ejyle.DevAccelerate.Notifications.EF;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Notifications.SendGrid
{
    public static class DaNotificationsServiceSGExtensions
    {
        public static async Task SendEmailsAsync(this DaNotificationsService service, DaMailSettings settings)
        {
            var paginationCriteria = new DaDataPaginationCriteria(1, 1000);
            var result = await service.NotificationManager.FindAsync(paginationCriteria, Delivery.DaNotificationStatus.New, DaNotificationChannel.EmailNotification);

            if (result.Entities == null && result.Entities.Count > 0)
            {
                var mailProvider = new DaSendGridMailProvider(settings);
                foreach (var entity in result.Entities)
                {
                    await mailProvider.SendAsync(entity.RecipientAddress, entity.Subject, entity.Body);
                    entity.Status = Delivery.DaNotificationStatus.Delivered; 
                }

                await service.NotificationManager.UpdateAsync(result.Entities);
            }

            return;
        }
    }
}
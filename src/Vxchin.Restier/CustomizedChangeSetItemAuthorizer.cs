using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Restier.Core;
using Microsoft.Restier.Core.Submit;

namespace Vxchin.Restier
{
    public class CustomizedChangeSetItemAuthorizer : IChangeSetItemAuthorizer
    {
        private IChangeSetItemAuthorizer? InnerChangeSetItemAuthorizer { get; set; }

        public async Task<bool> AuthorizeAsync(SubmitContext context, ChangeSetItem item,
            CancellationToken cancellationToken)
        {
            if (item is DataModificationItem modificationItem &&
                modificationItem.EntitySetOperation > RestierEntitySetOperation.Filter)
                throw new StatusCodeException(HttpStatusCode.MethodNotAllowed, "不支持对数据集的修改。");
            if (InnerChangeSetItemAuthorizer is null)
                throw new InvalidOperationException($"{nameof(InnerChangeSetItemAuthorizer)} should not be null.");
            return await InnerChangeSetItemAuthorizer.AuthorizeAsync(context, item, cancellationToken);
        }
    }
}
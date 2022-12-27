// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

import { dotnet } from './dotnet.js'

const { setModuleImports, getAssemblyExports, getConfig } = await dotnet
    .withDiagnosticTracing(false)
    .withApplicationArgumentsFromQuery()
    .create();

setModuleImports('main.js', {
    window: {
        location: {
            href: () => globalThis.window.location.href
        }
    }
});

const config = getConfig();
const exports = await getAssemblyExports(config.mainAssemblyName);
var order = {
    total: 19,
    orderItems: [
        {
            orderItemId: 'cc4c06b8-e889-4fc1-b452-6a2539d20796',
            orderId: '17db993e-d726-431c-957d-aa28ad7f0186',
            subTotal: 9
        },
        {
            orderItemId: 'cc4c06b8-e889-4fc1-b452-6a2539d20796',
            orderId: '17db993e-d726-431c-957d-aa28ad7f0186',
            subTotal: 10
        }
    ]
}
const validateResult = exports.MyWasm.ValidateOrder(JSON.stringify(order));
console.log(validateResult);
document.getElementById('out').innerHTML = validateResult == null ? 'No issue found' : `<font color=red>${validateResult}</font>`;
await dotnet.run();
export const mapToItems = obj => {
    const newItems = [];
    for (const key in obj) {
        const item = {
            id: obj[key].id,
            name: obj[key].item.itemName,
            cost: obj[key].cost,
            code: obj[key].currencyCode,
            imageUrl: obj[key].item.imageUrl.url
        }
        newItems.push(item);
    }

    return newItems;
}

export const mapToItem = obj => {
    const item = {
        id: obj.id,
        name: obj.item.itemName,
        description: obj.item.description,
        cost: obj.cost,
        tags: obj.item.tags,
        brandId: obj.item.brand.id,
        brand: obj.item.brand.name,
        typeId: obj.item.type.id,
        type: obj.item.type.name,
        code: obj.currencyCode,
        imagesUrl: obj.item.imagesUrl
    }

    return item;
}

export const mapToCurrencies = (obj) => {
    const newCurrencies = [];
    for (const key in obj) {
        const item = {
            id: obj[key].id,
            code: obj[key].code,
            description: obj[key].description
        }
        newCurrencies.push(item);
    }

    return newCurrencies;
};

export const mapToCurrency = (obj) => {
    const currency = {
        id: obj.id,
        code: obj.code,
        description: obj.description
    }

    return currency;
};

export const mapToCurrencyRates = (obj) => {
    const newCurrencies = [];
    for (const key in obj) {
        const item = {
            id: obj[key].id,
            code: obj[key].code,
            currencyId: obj[key].currencyId,
            rate: obj[key].rate,
            currencyDate: obj[key].currencyDate
        }
        newCurrencies.push(item);
    }

    return newCurrencies;
};

export const mapToOrderItems = (obj) => {
    const newOrderItems = [];
    
    for(const key in obj) {
        const orderItem = {
            id: obj[key].id,
            itemCartId: obj[key].itemCartId,
            itemName: obj[key].itemCart.itemName,
            brandName: obj[key].itemCart.brandName,
            typeName: obj[key].itemCart.typeName,
            description: obj[key].itemCart.description,
            tags: obj[key].itemCart.tags,
            images: obj[key].itemCart.imagesUrl,
            sourceCost: obj[key].itemCart.cost,
            created: new Date(obj[key].itemCart.created).toLocaleString(),
            sourceCode: obj[key].itemCart.currencyCode,
            code: obj[key].code,
            rate: obj[key].rate,
            cost: obj[key].cost,
            userId: obj[key].userId
        }
        newOrderItems.push(orderItem);
    }

    return newOrderItems;
}

export const mapToOrderItem = (obj) => {
    const orderItem = {
        id: obj.id,
        itemCartId: obj.itemCartId,
        itemName: obj.itemCart.itemName,
        brandName: obj.itemCart.brandName,
        typeName: obj.itemCart.typeName,
        description: obj.itemCart.description,
        tags: obj.itemCart.tags,
        images: obj.itemCart.imagesUrl,
        sourceCost: obj.itemCart.cost,
        created: new Date(obj.itemCart.created).toLocaleString(),
        sourceCode: obj.itemCart.currencyCode,
        code: obj.code,
        rate: obj.rate,
        cost: obj.cost,
        userId: obj.userId
    }

    return orderItem;
}

export const mapToCustomers = (obj) => {
    const newCustomers = [];
    
    for(const key in obj) {
        const customer = {
            id: obj[key].id,
            firstName: obj[key].firstName,
            lastName: obj[key].lastName,
            company: obj[key].company,
            companyName: obj[key].companyName,
            nip: obj[key].nip,
            phoneNumber: obj[key].phoneNumber,
            userId: obj[key].userId
        }
        newCustomers.push(customer);
    }

    return newCustomers;
}

export const mapToCustomer = (obj) => {
    const customer = {
        id: obj.id,
        firstName: obj.firstName,
        lastName: obj.lastName,
        company: obj.company,
        companyName: obj.companyName,
        nip: obj.nip,
        phoneNumber: obj.phoneNumber,
        address: {
            id: obj.address.id,
            cityName: obj.address.cityName,
            streetName: obj.address.streetName,
            countryName: obj.address.countryName,
            zipCode: obj.address.zipCode,
            buildingNumber: obj.address.buildingNumber,
            localeNumber: obj.address.localeNumber,
            customerId: obj.address.customerId
        },
        userId: obj.userId
    }

    return customer;
}

export const mapToOrder = (obj) => {
    const order = {
        id: obj.id,
        orderNumber: obj.orderNumber,
        createOrderDate: obj.createOrderDate,
        orderApprovedDate: obj.orderApprovedDate,
        cost: obj.cost,
        customerId: obj.customerId,
        userId: obj.userId,
        paid: obj.paid,
        orderItems: mapToOrderItems(obj.orderItems),
        payments: mapToPayments(obj.payments)
    };

    return order;
}

export const mapToPayments = (objects) => {
    const payments = [];

    for(const obj of objects) {
        const payment = {
            id: obj.id,
            paymentNumber: obj.paymentNumber,
            paymentDate: obj.paymentDate,
            userId: obj.userId
        };
        payments.push(payment);
    }

    return payments;
}
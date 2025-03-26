
public long GetPrice(long productId, bool isMember){
    
    var productInfo = productManager.GetById(productId);
    if(productInfo == null ){
        
        throw new Exception("Product not found.");
    }

    return isMember ? productInfo.price * productInfo.discountRate : productInfo.price;
}

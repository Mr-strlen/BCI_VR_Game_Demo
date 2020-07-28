function GetChannelDataCallBack( obj, event, nChan, bufferSize )
%GetChannelDataCallBack Summary of this function goes here
%   Detailed explanation goes here
    rawData = fread(obj, obj.BytesAvailableFcnCount/4, 'float');
    data = reshape(rawData, nChan, length(rawData)/nChan);
    obj.UserData = [obj.UserData data];
    userDataLength = size(obj.UserData,2);
    if userDataLength > bufferSize
        obj.UserData = obj.UserData(:, (end-bufferSize+1):end);
    end
end
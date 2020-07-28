classdef DataClient < handle
    %DATACLIENT TCP/IP data client
    %   Detailed explanation goes here
    
    properties (Constant)
        updateInterval = 0.04; % 40ms
    end
    
    properties
        TCPIP;
        serverPort;
        ipAddress;
        nChan;
        sampleRate;
    end
    
    methods
        
        function obj = DataClient(ipAddress, serverPort, nChan, sampleRate, bufferSize)
            obj.serverPort = serverPort;
            obj.ipAddress = ipAddress;
            obj.nChan = nChan;
            obj.sampleRate = sampleRate;
            obj.TCPIP = tcpip(obj.ipAddress, obj.serverPort);
            
            if round(obj.sampleRate * obj.updateInterval) > 1
                updatePoints = round(obj.sampleRate * obj.updateInterval);
            else
                updatePoints = obj.sampleRate;
            end
            obj.TCPIP.BytesAvailableFcnCount = 4 * obj.nChan * updatePoints;
            obj.TCPIP.BytesAvailableFcnMode = 'byte';
            obj.TCPIP.BytesAvailableFcn = {@GetChannelDataCallBack, obj.nChan, bufferSize*obj.sampleRate};
            obj.TCPIP.InputBufferSize = obj.TCPIP.BytesAvailableFcnCount * 10;
            obj.TCPIP.ByteOrder = 'littleEndian';
        end
        
        function Open(obj)
            fopen(obj.TCPIP);
        end
        
        function Close(obj)
            fclose(obj.TCPIP);
        end
        
        function [data] = GetBufferData(obj)
            data = obj.TCPIP.UserData;
        end
        
    end
    
end


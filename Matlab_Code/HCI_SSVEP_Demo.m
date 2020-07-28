
%% Initialization

% SSVEP set up
trial_times=5;
target_frequency=[6.67,8.57,10,12,15]; % here insert the flicker frequency
trial_length=3; % here insert the length of window, in seconds
cut_length=0.5;
% Create data reciever
disp('building dataClient...');
ipAddress = 'localhost'; % Data server IP address
serverPort = 8712; % Data server port
nChan = 9; % Number of channels, including EEG data channels plus 1 event channel
sampleRate =1000; % Sampling rate
bufferSize =trial_length; % Data buffer size, in seconds
dataClient = DataClient(ipAddress, serverPort, nChan, sampleRate, bufferSize); % Create client object
disp('preparing ...');
dataClient.Open;
display('connected ')
pause(0.1)

% setup bandpass filter
pass_band=[0.5,40]; % here insert filter parameter
fltorder = round(2*sampleRate/3)-500;
Fn = sampleRate/2;
[b, a] = fir1(fltorder, [pass_band(1)/Fn pass_band(2)/Fn]);



% CCA set up
t=0:1/sampleRate:trial_length-0.001;
cca_ref_1=[sin(2*pi*target_frequency(1)*t);
    sin(2*pi*2*target_frequency(1)*t);
    cos(2*pi*target_frequency(1)*t);
    cos(2*pi*2*target_frequency(1)*t)];
cca_ref_2=[sin(2*pi*target_frequency(2)*t);
    sin(2*pi*2*target_frequency(2)*t);
    cos(2*pi*target_frequency(2)*t);
    cos(2*pi*2*target_frequency(2)*t)];
cca_ref_3=[sin(2*pi*target_frequency(3)*t);
    sin(2*pi*2*target_frequency(3)*t);
    cos(2*pi*target_frequency(3)*t);
    cos(2*pi*2*target_frequency(3)*t)];
cca_ref_4=[sin(2*pi*target_frequency(4)*t);
    sin(2*pi*2*target_frequency(4)*t);
    cos(2*pi*target_frequency(4)*t);
    cos(2*pi*2*target_frequency(4)*t)];
cca_ref_5=[sin(2*pi*target_frequency(5)*t);
    sin(2*pi*2*target_frequency(5)*t);
    cos(2*pi*target_frequency(5)*t);
    cos(2*pi*2*target_frequency(5)*t)];
% input the subject number
 sub_num=input('please input the subject number');
% prepare the dataset
data.sampleRate=sampleRate;
data.nChan=nChan;
file_name=[num2str(sub_num),'_HCI.mat'];

% prepare game 
% game_mode=true;
% t_send= tcpip('localhost', 12592); % here insert the IP and port of the HCI computer
% trial_count=0;
% pause(0.1);

%% main function 
%while game_mode==true
trial_count=1;
while trial_count<trial_times
    trial_count=trial_count+1;
    pause(trial_length-0.02);
    [data,target] = getEEG_target( cca_ref_1,cca_ref_2,cca_ref_3,cca_ref_4,cca_ref_5,b,a,dataClient,data,trial_count,sampleRate,cut_length );
    display('target found')
    % send the result to the HCI computer
    t_send.OutputBufferSize=4096;
   % fopen(t_send);
    message= [num2str(target), '!'];
    %fwrite(t_send,message,'uint8');
    display('data sent!')
    %fclose(t_send);
end
% save datasets
%save(file_name,'data')


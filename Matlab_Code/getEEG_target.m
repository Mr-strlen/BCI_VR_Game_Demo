function [data,target] = getEEG_target( cca_ref_1,cca_ref_2,cca_ref_3,cca_ref_4,cca_ref_5,b,a,dataClient,data,trial_count,sampleRate,cut_length )
    pause(0.01)
    data_online = dataClient.GetBufferData; % Get data from buffer
    for i=1:2
        data_O=data_online(i+6,cut_length*sampleRate+1:end);
        data_filtered(i,:)= filtfilt(b,a,double(data_O));
    end
    cca_ref_1=cca_ref_1(:,sampleRate*cut_length+1:end);
    cca_ref_2=cca_ref_2(:,sampleRate*cut_length+1:end);
    cca_ref_3=cca_ref_3(:,sampleRate*cut_length+1:end);
    cca_ref_4=cca_ref_4(:,sampleRate*cut_length+1:end);
    cca_ref_5=cca_ref_5(:,sampleRate*cut_length+1:end);
    display(num2str(size(data_filtered)))
    [A,B,cor1]=canoncorr(data_filtered',cca_ref_1');
    [A,B,cor2]=canoncorr(data_filtered',cca_ref_2');
    [A,B,cor3]=canoncorr(data_filtered',cca_ref_3');
    [A,B,cor4]=canoncorr(data_filtered',cca_ref_4');
    [A,B,cor5]=canoncorr(data_filtered',cca_ref_5');
    cor=[cor1(1),cor2(1),cor3(1),cor4(1),cor5(1)];
    display(num2str(cor))
    target=find(max(cor)==cor);
    target=target(1);
    display(['this target is ',num2str(target)]);
    % save data
    data.trial{trial_count}=data_online;
    data.target{trial_count}=target;
end


package com.example.subhradeep.chatapplication;

import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentTransaction;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import com.example.subhradeep.chatapplication.Model.Message;
import com.example.subhradeep.chatapplication.Services.ServiceBuilder;
import com.example.subhradeep.chatapplication.Services.appService;

import java.util.ArrayList;
import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class MessageFragment extends Fragment {

    ListView listView;
    EditText editText;
    Button button;
    Void messages;
    List<Message> uMessage;

    public MessageFragment() {
        // Required empty public constructor
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {

        View v = inflater.inflate(R.layout.fragment_message, container, false);
        listView = (ListView) v.findViewById(R.id.listView2);

        Bundle bundle = getArguments();
        if (bundle != null) {
            String[] message = bundle.getStringArray("Message");
            for (int i = 0; i < message.length; i++) {
                listView.setAdapter(new ArrayAdapter<String>(
                        getContext(),
                        android.R.layout.simple_list_item_1,
                        message
                ));
            }
        }
        return v;
    }

    @Override
    public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        editText = (EditText) view.findViewById(R.id.editText);
        button = (Button) view.findViewById(R.id.buttonSend);

        button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                final Message message = new Message();
                message.setMessage(editText.getText().toString());
                message.setToUserId(UserFragment.uId);

                appService messageService = ServiceBuilder.buildService(appService.class);
                Call<Void> send = messageService.sendMessage(message, MainActivity.token, "application/json");
                final Call<List<Message>> userMessage = messageService.getMessages(UserFragment.uId, MainActivity.token);

                send.enqueue(new Callback<Void>() {
                    @Override
                    public void onResponse(Call<Void> call, Response<Void> response) {
                        Toast.makeText(getContext(), "Request Success", Toast.LENGTH_LONG).show();
                        messages = response.body();

                        userMessage.enqueue(new Callback<List<Message>>() {
                            @Override
                            public void onResponse(Call<List<Message>> call, Response<List<Message>> response) {
                                uMessage = response.body();
                                String[] userMessage = new String[uMessage.size()];
                                String[] userId = new String[uMessage.size()];

                                for (int i = 0; i < uMessage.size(); i++) {
                                    userMessage[i] = String.valueOf(String.valueOf(String.valueOf(uMessage.get(i).getFromUserId()) + " => " + String.valueOf(uMessage.get(i).getMessage())));
                                }
                                Bundle bundle = new Bundle();
                                MessageFragment mFragment = new MessageFragment();
                                bundle.putStringArray("Message", userMessage);
                                mFragment.setArguments(bundle);                // data send through bundle

                                FragmentManager fManager = getFragmentManager();
                                fManager.beginTransaction().replace(R.id.linearLayout2, mFragment).commit();
                            }

                            @Override
                            public void onFailure(Call<List<Message>> call, Throwable t) {
                                Toast.makeText(getContext(), "Wrong response", Toast.LENGTH_LONG).show();
                            }
                        });
                        refresh();
                    }

                    @Override
                    public void onFailure(Call<Void> call, Throwable t) {
                        Toast.makeText(getContext(), "Wrong response", Toast.LENGTH_LONG).show();
                    }
                });
            }
        });
    }

    public void refresh() {
        Bundle bundle = getArguments();
        if (bundle != null) {
            String[] userMessage = bundle.getStringArray("Message");
            for (int i = 0; i < userMessage.length; i++) {
                listView.setAdapter(new ArrayAdapter<String>(
                        getContext(),
                        android.R.layout.simple_list_item_1,
                        userMessage
                ));
            }
        }
    }
}

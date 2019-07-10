package com.example.subhradeep.chatapplication;


import android.content.Intent;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentTransaction;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.Toast;

import com.example.subhradeep.chatapplication.Model.Message;
import com.example.subhradeep.chatapplication.Model.User;
import com.example.subhradeep.chatapplication.Services.ServiceBuilder;
import com.example.subhradeep.chatapplication.Services.appService;

import java.util.ArrayList;
import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class UserFragment extends Fragment {

    ListView listView1;
    List<User> users;
    List<Message> messages;
    public static int id;
    public static String name;
    public static int uId;


    public UserFragment() {
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment

        View v = inflater.inflate(R.layout.fragment_user, container, false);
        listView1 = (ListView) v.findViewById(R.id.listView1);

        final appService userService = ServiceBuilder.buildService(appService.class);
        Call<List<User>> userRequest = userService.getChats(MainActivity.token);

        userRequest.enqueue(new Callback<List<User>>() {
                @Override
                public void onResponse(Call<List<User>> call, Response<List<User>> response) {
                    users = response.body();

                    String[] userName = new String[users.size()];

                    for( int i =0;i< users.size(); i++) {
                        userName[i] = users.get(i).getName();

                        listView1.setAdapter(new ArrayAdapter<String>(
                                getContext(),
                                android.R.layout.simple_list_item_1,
                                userName)
                        );
                    }
                }
            @Override
            public void onFailure(Call<List<User>> call, Throwable t) {
                Toast.makeText(getContext(), "Wrong response", Toast.LENGTH_LONG).show();
            }
        });

        listView1.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            public void onItemClick(AdapterView<?> parent, View view,
                                    final int position, long id) {

                final appService messageService = ServiceBuilder.buildService(appService.class);
                Call<List<Message>> userMessage = messageService.getMessages(users.get(position).getId(), MainActivity.token);
                uId = users.get(position).getId();
                final String uName = users.get(position).getName();

                userMessage.enqueue(new Callback<List<Message>>() {
                    @Override
                    public void onResponse(Call<List<Message>> call, Response<List<Message>> response) {
                        messages = response.body();
                        String[] userMessage = new String[messages.size()];
                        String[] userId = new String[messages.size()];

                        for( int i =0;i< messages.size(); i++) {
                            userMessage[i] = String.valueOf( String.valueOf( String.valueOf(messages.get(i).getFromUserId()) + " => " + String.valueOf(messages.get(i).getMessage())));
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
                        Toast.makeText(getContext(), "Wrong request", Toast.LENGTH_LONG);
                    }
                });
            }
        });
    return v;
    }
}

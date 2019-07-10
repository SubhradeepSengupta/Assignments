package com.example.subhradeep.chatapplication;

import android.content.Context;
import android.content.SharedPreferences;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
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
import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;
import java.lang.reflect.Type;
import java.util.ArrayList;
import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class MessageFragment extends Fragment {

    ListView listView;
    EditText editText;
    Button button;
    List<Message> uMessage;
    public ArrayList<Message> extraMessage;
    public ArrayList<Message> newMessage;
    Message message,extraMessages;

    public MessageFragment() {
        extraMessage = new ArrayList<Message>();
        newMessage = new ArrayList<Message>();
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

        final SharedPreferences sharedPreferences = getContext().getSharedPreferences(getContext().getPackageName() + ".extraMessages", Context.MODE_PRIVATE);
        final SharedPreferences.Editor editor = sharedPreferences.edit();

        button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                // if network is not available
                if(!isActive()) {
                    Toast.makeText(getContext(), "Network Not Available", Toast.LENGTH_LONG).show();

                    extraMessages = new Message();
                    extraMessages.setMessage(editText.getText().toString());
                    extraMessages.setToUserId(UserFragment.uId);

                    extraMessage.add(extraMessages);

                    Gson gson = new Gson();

                    String jsonString = gson.toJson(extraMessage);
                    editor.putString("extraValue", jsonString);
                    editor.apply();
                    refresh();
                }
                else {
                    String jsonString1 = sharedPreferences.getString("extraValue", null);
                    Gson gson = new Gson();
                    Type type = new TypeToken<ArrayList<Message>>() {}.getType();
                    newMessage = gson.fromJson(jsonString1, type);

                    if (newMessage != null)
                    {
                        appService messageService1 = ServiceBuilder.buildService(appService.class);
                        for (int i = 0; i < newMessage.size(); i++) {
                            final Message message = newMessage.get(i);
                            Call<Void> send = messageService1.sendMessage(message, MainActivity.token);
                            send.enqueue(new Callback<Void>() {
                                @Override
                                public void onResponse(Call<Void> call, Response<Void> response)
                                {
                                    Toast.makeText(getContext(), "Request Success", Toast.LENGTH_LONG).show();
                                }
                                @Override
                                public void onFailure(Call<Void> call, Throwable t)
                                {
                                    Log.e("Failure", message.getMessage());
                                    Log.e("Failure", t.getLocalizedMessage());
                                    t.printStackTrace();
                                    MainActivity.showMessage("");
                                }
                            });
                       }
                        editor.clear();
                        editor.commit();
                    }
 ///////////////////////////////////// //////////////////////////////////////////////////////////////////////////////////
                        message = new Message();
                        message.setMessage(editText.getText().toString());
                        message.setToUserId(UserFragment.uId);

                        appService messageService2 = ServiceBuilder.buildService(appService.class);
                        Call<Void> send2 = messageService2.sendMessage(message, MainActivity.token);
                        final Call<List<Message>> userMessage2 = messageService2.getMessages(UserFragment.uId, MainActivity.token);

                        send2.enqueue(new Callback<Void>() {
                            @Override
                            public void onResponse(Call<Void> call, Response<Void> response) {
                                Toast.makeText(getContext(), "Request Success", Toast.LENGTH_LONG).show();

                                userMessage2.enqueue(new Callback<List<Message>>() {
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
                                        //Toast.makeText(getContext(), "Wrong response", Toast.LENGTH_LONG).show();
                                    }
                                });
                            }

                            @Override
                            public void onFailure(Call<Void> call, Throwable t) {
                                //Toast.makeText(getContext(), "Wrong response", Toast.LENGTH_LONG).show();
                            }
                        });
                        refresh();
                }
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

    public boolean isActive() {
        ConnectivityManager manager = (ConnectivityManager) getActivity().getSystemService(Context.CONNECTIVITY_SERVICE);
        NetworkInfo info = manager.getActiveNetworkInfo();
        if (info != null && info.isConnected()) {
            return true;
        }
        return false;
    }
}

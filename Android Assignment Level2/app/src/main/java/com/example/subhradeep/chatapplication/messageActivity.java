package com.example.subhradeep.chatapplication;

import android.content.Context;
import android.content.Intent;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.ListFragment;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.RecyclerView;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.SimpleAdapter;
import android.widget.TextView;
import android.widget.Toast;

import com.example.subhradeep.chatapplication.Model.User;
import com.example.subhradeep.chatapplication.Services.ServiceBuilder;
import com.example.subhradeep.chatapplication.Services.appService;
import com.google.gson.Gson;

import org.w3c.dom.Text;

import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

public class messageActivity extends AppCompatActivity {

    ListView listView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_message);
        //listView = (ListView) findViewById(R.id.listView);

        // retrofit object build and creation of converterfactory
        Retrofit retrofit = new Retrofit.Builder()
                .baseUrl(ServiceBuilder.URL)
                .addConverterFactory(GsonConverterFactory.create())
                .build();

        UserFragment userFragment = new UserFragment();
        FragmentManager manager = getSupportFragmentManager();
        manager.beginTransaction()
                .replace(R.id.linearLayout1, userFragment, userFragment.getTag())
                .commit();

        MessageFragment messageFragment = new MessageFragment();
        manager.beginTransaction()
                .replace(R.id.linearLayout2, messageFragment, messageFragment.getTag())
                .commit();

    }
}

package com.example.subhradeep.chatapplication;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import com.example.subhradeep.chatapplication.Model.User;
import com.example.subhradeep.chatapplication.Services.ServiceBuilder;
import com.example.subhradeep.chatapplication.Services.appService;

import javax.xml.datatype.Duration;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class MainActivity extends AppCompatActivity {

    public EditText loginName;
    Button buttonLogin, buttonRegister;
    public static String token;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        buttonLogin = (Button) findViewById(R.id.buttonLogin);
        buttonLogin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                User user = new User();
                loginName = (EditText) findViewById(R.id.loginName);

                if (loginName.getText().toString().trim().isEmpty() || loginName.getText().toString().contains(" ")) {
                    Toast.makeText(getApplicationContext(), "User Name should not be null or contain blank spaces", Toast.LENGTH_LONG).show();
                } else {
                    user.setName(loginName.getText().toString());
                    appService service = ServiceBuilder.buildService(appService.class);
                    Call<User> createRequest = service.createUser(user);

                    createRequest.enqueue(new Callback<User>() {
                        @Override
                        public void onResponse(Call<User> call, Response<User> response) {
                            Toast.makeText(getApplicationContext(), "Request Success", Toast.LENGTH_LONG).show();
                            Intent intent = new Intent(getApplicationContext(), messageActivity.class);
                            startActivity(intent);
                            token = response.body().getToken();
                        }

                        @Override
                        public void onFailure(Call<User> call, Throwable t) {
                            Toast.makeText(getApplicationContext(), "Request Not Success", Toast.LENGTH_LONG).show();
                        }
                    });
                }
            }
        });
    }
}


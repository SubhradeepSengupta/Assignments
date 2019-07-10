package com.example.subhradeep.chatapplication.Services;

import com.example.subhradeep.chatapplication.MainActivity;
import com.example.subhradeep.chatapplication.Model.Message;
import com.example.subhradeep.chatapplication.Model.User;

import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.List;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.GET;
import retrofit2.http.Header;
import retrofit2.http.Headers;
import retrofit2.http.POST;
import retrofit2.http.Path;

public interface appService {

    // Get all User Names
    @GET("user")
    Call<List<User>> getChats(@Header("Authorization")String token);

    // Get messages of particular user
    @GET("chat/{id}")
    Call<List<Message>> getMessages(@Path("id")int id, @Header("Authorization")String token);

    // Login Request
    @POST("user/login")
    Call<User> createUser(@Body User user);

    @POST("chat")
    Call<Void> sendMessage(@Body Message message, @Header("Authorization")String token, @Header("Content-Type")String type);
}

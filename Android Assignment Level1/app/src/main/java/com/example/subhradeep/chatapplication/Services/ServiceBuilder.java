package com.example.subhradeep.chatapplication.Services;

import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

/**
 * Created by Subhradeep on 08-03-2019.
 */

public class ServiceBuilder {

    // defining the base url so all the request will be in this domain
    public static final String URL = "https://chat.promactinfo.com/api/";

    // registering the GSON converter library
    private static Retrofit.Builder builder = new Retrofit.Builder()
            .baseUrl(URL)
            .addConverterFactory(GsonConverterFactory.create());

    private static Retrofit retrofit = builder.build();

    // implementation of appService can be created through this method
    public static <S> S buildService(Class<S> serviceType) {
        return retrofit.create(serviceType);
    }
}

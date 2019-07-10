//
//  ViewControllerThird.m
//  Assignment1_6
//
//  Created by Subhradeep  on 3/22/19.
//  Copyright © 2019 Subhradeep . All rights reserved.
//

#import "ViewControllerThird.h"
#import "CustomCell.h"

@interface ViewControllerThird () {
    NSUserDefaults *defaults;
    NSArray *path;
    NSString *documentsPath;
    NSString *filePath, *newFilePaths;
}

@end

@implementation ViewControllerThird
@synthesize index, imageDisplay, userIdLabel, userNameLabel, userPositionLabel, userAddressLabel, maleBtn, femaleBtn, demoId, demoName, demoPosition, demoAddress, demoGender, idArray, nameArray, positionArray, genderArray, addressArray;

- (void)viewDidLoad {
    [super viewDidLoad];
    idArray = [[NSMutableArray alloc]init];
    nameArray = [[NSMutableArray alloc]init];
    positionArray = [[NSMutableArray alloc]init];
    genderArray = [[NSMutableArray alloc]init];
    addressArray = [[NSMutableArray alloc]init];
    
     defaults = [NSUserDefaults standardUserDefaults];
    
    path = NSSearchPathForDirectoriesInDomains(NSDocumentDirectory, NSUserDomainMask, YES);
    documentsPath = [path objectAtIndex:0];
    filePath = [documentsPath stringByAppendingPathComponent: [NSString stringWithFormat:@"%@_%@.jpeg", demoId, demoName]];
    imageDisplay.image = [UIImage imageWithContentsOfFile:filePath];
    
    userIdLabel.text = demoId;
    userNameLabel.text = demoName;
    userPositionLabel.text = demoPosition;
    userAddressLabel.text = demoAddress;
    
    if([demoGender containsString:@"Male"]) {
        self.maleBtn.selected = YES;
    }
    else {
        self.femaleBtn.selected = YES;
    }
}

- (IBAction)buttonMale:(id)sender {
    self.maleBtn.selected = !self.maleBtn.isSelected;
    
    if (self.maleBtn.isSelected)
    {
        self.femaleBtn.selected = NO;
    }
    else{
        self.maleBtn.selected = YES;
    }
}

- (IBAction)buttonFemale:(id)sender {
    self.femaleBtn.selected = !self.femaleBtn.isSelected;
    
    if (self.femaleBtn.isSelected)
    {
        self.maleBtn.selected = NO;
    }
    else{
        self.femaleBtn.selected = YES;
    }
}

- (IBAction)updateData:(id)sender {
    idArray = [[defaults objectForKey:@"UserId"]mutableCopy];
    nameArray = [[defaults objectForKey:@"UserName"]mutableCopy];
    positionArray = [[defaults objectForKey:@"UserPosition"]mutableCopy];
    genderArray = [[defaults objectForKey:@"UserGender"]mutableCopy];
    addressArray = [[defaults objectForKey:@"UserAddress"]mutableCopy];
    
    if([idArray containsObject: [NSString stringWithFormat:@"%@",demoId]]) {
        long pos = (long)[idArray indexOfObject:demoId];
        [idArray replaceObjectAtIndex:pos withObject:[NSString stringWithFormat:@"%@", userIdLabel.text]];
        [nameArray replaceObjectAtIndex:pos withObject:[NSString stringWithFormat:@"%@", userNameLabel.text]];
        [positionArray replaceObjectAtIndex:pos withObject:[NSString stringWithFormat:@"%@", userPositionLabel.text]];
        [addressArray replaceObjectAtIndex:pos withObject:[NSString stringWithFormat:@"%@", userAddressLabel.text]];
        
        if(maleBtn.isSelected) {
            [genderArray replaceObjectAtIndex:pos withObject:[NSString stringWithFormat:@"%@", maleBtn.currentTitle]];
        } else if(femaleBtn.isSelected) {
            [genderArray replaceObjectAtIndex:pos withObject:[NSString stringWithFormat:@"%@", femaleBtn.currentTitle]];
        } else {
            [genderArray replaceObjectAtIndex:pos withObject:[NSString stringWithFormat:@" "]];
        }
        
        NSFileManager *fileManager = [[NSFileManager alloc]init];
        newFilePaths = [documentsPath stringByAppendingPathComponent: [NSString stringWithFormat:@"%@_%@.jpeg", userIdLabel.text, userNameLabel.text]];
        [fileManager moveItemAtPath:filePath toPath:newFilePaths error:NULL];
        
        
        [defaults setObject:idArray forKey:@"UserId"];
        [defaults setObject:nameArray forKey:@"UserName"];
        [defaults setObject:positionArray forKey:@"UserPosition"];
        [defaults setObject:genderArray forKey:@"UserGender"];
        [defaults setObject:addressArray forKey:@"UserAddress"];
        
        [defaults synchronize];
    }

    [self.navigationController popToRootViewControllerAnimated:YES];
}


- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

@end

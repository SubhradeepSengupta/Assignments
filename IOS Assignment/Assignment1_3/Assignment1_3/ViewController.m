//
//  ViewController.m
//  Assignment1_3
//
//  Created by Subhradeep  on 3/18/19.
//  Copyright © 2019 Subhradeep . All rights reserved.
//

#import "ViewController.h"
#import "CustomCell.h"

@interface ViewController () <UICollectionViewDelegate, UICollectionViewDataSource>

@property NSArray *imageCollection;
@property NSArray *imageTitle;

@end

@implementation ViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    
    _imageCollection = [[NSArray alloc] initWithObjects:@"image1",@"image2",@"image3",@"image4",@"image5",@"image6",@"image7",@"image8",@"image9",@"image10", nil];
    
    _imageTitle = [[NSArray alloc] initWithObjects:@"Image1",@"Image2",@"Image3",@"Image4",@"Image5",@"Image6",@"Image7",@"Image8",@"Image9",@"Image10", nil];
}


- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (NSInteger)collectionView:(UICollectionView *)collectionView numberOfItemsInSection:(NSInteger)section {
    return _imageCollection.count;
}

- (NSInteger)numberOfSectionsInCollectionView:(UICollectionView *)collectionView {
    return 1;
}

- (__kindof UICollectionViewCell *)collectionView:(UICollectionView *)collectionView cellForItemAtIndexPath:(NSIndexPath *)indexPath {
    CustomCell *cell = [collectionView dequeueReusableCellWithReuseIdentifier:@"Cell" forIndexPath:indexPath];
    
    cell.imageArea.image = [UIImage imageNamed:[_imageCollection objectAtIndex:indexPath.row]];
    cell.labelArea.text = [_imageTitle objectAtIndex:indexPath.row];
    
    return cell;
}

@end
